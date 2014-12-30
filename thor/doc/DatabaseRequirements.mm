<map version="0.9.0">
<!-- To view this file, download free mind mapping software FreeMind from http://freemind.sourceforge.net -->
<node CREATED="1266947264886" ID="Freemind_Link_239912389" MODIFIED="1286152831099" STYLE="bubble" TEXT="Database Requirements">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<node CREATED="1266950106076" ID="_" MODIFIED="1267895389041" POSITION="right" TEXT="Support of multiple worlds at once"/>
<node CREATED="1266950303413" ID="Freemind_Link_997452926" MODIFIED="1267895403828" POSITION="left" TEXT="All objects consist of a set of fields" VSHIFT="23"/>
<node CREATED="1266950404151" ID="Freemind_Link_80642046" MODIFIED="1267895402978" POSITION="left" TEXT="Object`s fields can act as in/out data in the dependency graph" VSHIFT="3"/>
<node CREATED="1266950686160" ID="Freemind_Link_1594839353" MODIFIED="1267895391446" POSITION="right" TEXT="Fields have separate reader/writer intefaces. All readers return a fixed value for this timestep, writers are created for components that expose interest in updating this type of object(field?), they are implemented as a thread safe queue of commits, which are resolved when the framework has finished an update step" VSHIFT="-1"/>
<node CREATED="1266951546463" ID="Freemind_Link_1556232857" MODIFIED="1267895400449" POSITION="left" TEXT="Objects have to be fully reflective, they should be created from some kind of a blueprint" VSHIFT="2"/>
<node CREATED="1266951784313" ID="Freemind_Link_1697798870" MODIFIED="1267895392320" POSITION="right" TEXT="Commit queue should have a strategy that describes how to merge multiple commits into a final value(priority, time)" VSHIFT="3"/>
<node CREATED="1266953395516" ID="Freemind_Link_1809188262" MODIFIED="1267895399714" POSITION="left" TEXT="Dependencies in dependency graph are resolved after all object`s commit queues are merged" VSHIFT="-8"/>
<node CREATED="1266953575189" ID="Freemind_Link_1059468027" MODIFIED="1267895393141" POSITION="right" TEXT="Object`s fields should have a set of delegates(OnChanged etc.)" VSHIFT="5"/>
<node CREATED="1266953711466" ID="Freemind_Link_115499767" MODIFIED="1267895398936" POSITION="left" TEXT="Object factory should either post events or invoke delegates when objects are created/destroyed" VSHIFT="-9"/>
<node CREATED="1266954362825" ID="Freemind_Link_1125465596" MODIFIED="1267895431469" POSITION="right" TEXT="Maybe fields should have some kind of a semantic to distinguish them" VSHIFT="1"/>
<node CREATED="1266961803604" ID="Freemind_Link_1374028" MODIFIED="1267895397794" POSITION="left" TEXT="Besides the worlds there should be a section with global objects" VSHIFT="-4"/>
<node BACKGROUND_COLOR="#ff0000" CREATED="1266975620610" ID="Freemind_Link_172207009" MODIFIED="1291893628229" POSITION="right" TEXT="There should be an ability to add new fields to objects at runtime" VSHIFT="-2"/>
<node CREATED="1267486536125" ID="Freemind_Link_508358953" MODIFIED="1267895396964" POSITION="left" TEXT="There should be a serialization protocol, independent from the underlying implementation(XML, Google Protocol Buffers) as much as possible" VSHIFT="-8"/>
<node CREATED="1285342868094" ID="ID_623309867" MODIFIED="1285342925364" POSITION="right" TEXT="Support for creating lookahead values of fields, can be useful for AI planning"/>
<node CREATED="1286152642558" ID="ID_700490882" MODIFIED="1286152742367" POSITION="right" TEXT="Should implement a field cache, that caches specidied types of fields and keeps track of updated ones from the previous framework update."/>
</node>
</map>
