#include <glew/glew.h>
#include <Thor/Graphics/GraphicsWorkbench/MainView.h>

#include <QtCore/QThread>
#include <QGuiApplication>
#include <QtQuick/QQuickView>

#include "threadrenderer.h"

int main(int argc, char **argv)
{
    QGuiApplication app(argc, argv);

    /*if (!QGuiApplicationPrivate::platform_integration->hasCapability(QPlatformIntegration::ThreadedOpenGL)) {
        QQuickView view;
        view.setSource(QUrl("qrc:///scenegraph/textureinthread/error.qml"));
        view.show();
        return app.exec();
    }*/

    qmlRegisterType<ThreadRenderer>("SceneGraphRendering", 1, 0, "Renderer");
    int execReturn = 0;

    {
        MainView view;

        // Rendering in a thread introduces a slightly more complicated cleanup
        // so we ensure that no cleanup of graphics resources happen until the
        // application is shutting down.
        view.setPersistentOpenGLContext(true);
        view.setPersistentSceneGraph(true);

        view.setResizeMode(QQuickView::SizeRootObjectToView);
		QString Path(THOR_CONTENT_PATH);
		Path += "\\GraphicsWorkbench\\qt\\main.qml";
        view.setSource(QUrl::fromLocalFile(Path));
        view.show();
		glewExperimental = GL_TRUE;
		GLenum res = glewInit();
		int Major = 0;
		int Minor = 0;
		glGetIntegerv(GL_MAJOR_VERSION, &Major);
		glGetIntegerv(GL_MINOR_VERSION, &Minor);
		const GLubyte* Version = glGetString(GL_VERSION);
		const GLubyte* Vendor = glGetString(GL_VENDOR);
		const GLubyte* Renderer = glGetString(GL_RENDER);
		const GLubyte* Glsl = glGetString(GL_SHADING_LANGUAGE_VERSION);
        execReturn = app.exec();
    }

    // As the render threads make use of our QGuiApplication object
    // to clean up gracefully, wait for them to finish before
    // QGuiApp is taken off the heap.
    foreach (QThread *t, ThreadRenderer::threads) {
        t->wait();
        delete t;
    }

    return execReturn;
}
