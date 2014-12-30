<map version="0.8.1">
<!-- To view this file, download free mind mapping software FreeMind from http://freemind.sourceforge.net -->
<node CREATED="1264899405867" ID="Freemind_Link_561625818" MODIFIED="1265674264341" STYLE="bubble" TEXT="FrameworkLifetime">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<node BACKGROUND_COLOR="#3333ff" CREATED="1264899492499" FOLDED="true" HGAP="106" ID="_" LINK="FrameworkStartup.mm" MODIFIED="1265674289150" POSITION="right" TEXT="Framework Startup" VSHIFT="-269">
<arrowlink COLOR="#ff0000" DESTINATION="Freemind_Link_680737216" ENDARROW="Default" ENDINCLINATION="243;0;" ID="Freemind_Arrow_Link_50365122" STARTARROW="None" STARTINCLINATION="243;0;"/>
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<node BACKGROUND_COLOR="#99ff00" COLOR="#000000" CREATED="1264716516905" ID="Freemind_Link_429086766" MODIFIED="1264967596599" TEXT="Create framework object" VSHIFT="-164">
<edge COLOR="#000000"/>
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<icon BUILTIN="forward"/>
<node BACKGROUND_COLOR="#99ff99" COLOR="#000000" CREATED="1264716528498" ID="Freemind_Link_1020883058" MODIFIED="1265559022527" TEXT="Process application definition" VSHIFT="197">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<icon BUILTIN="forward"/>
<node BACKGROUND_COLOR="#99ff99" CREATED="1264881568246" ID="Freemind_Link_403464884" MODIFIED="1265559035961" TEXT="Application does not exist in the framework">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<icon BUILTIN="forward"/>
<node BACKGROUND_COLOR="#3333ff" COLOR="#000000" CREATED="1264716544912" ID="Freemind_Link_255136935" MODIFIED="1265673272703" TEXT="Create components, all requested ones should be  accessible to the framework statically. Plugins are loaded from dynamic libraries if the platform makes it possible." VSHIFT="-193">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<icon BUILTIN="forward"/>
<node BACKGROUND_COLOR="#99ff99" CREATED="1264716908987" ID="Freemind_Link_1732047789" MODIFIED="1265559099668" TEXT="Register component`s  provided interfaces " VSHIFT="212">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<icon BUILTIN="forward"/>
<node CREATED="1264717125598" ID="Freemind_Link_331806932" MODIFIED="1264881365063" TEXT="Build component dependency graph based on their provided/requested interfaces, which is to be used when it is required to add/remove new components at runtime." VSHIFT="-191">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<icon BUILTIN="forward"/>
<node BACKGROUND_COLOR="#99ff99" CREATED="1264717708700" HGAP="32" ID="Freemind_Link_266639640" MODIFIED="1265559114763" TEXT="Attach component event listeners based on the info about subscribed events" VSHIFT="217">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<icon BUILTIN="forward"/>
</node>
</node>
</node>
</node>
</node>
<node BACKGROUND_COLOR="#99ff99" CREATED="1264881653650" ID="Freemind_Link_688584262" MODIFIED="1265559047746" TEXT="Application already exists, &#xa;I`ve decided not to support&#xa; multi application framework&#xa; for now" VSHIFT="90">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<icon BUILTIN="forward"/>
<node CREATED="1264881672943" HGAP="74" ID="Freemind_Link_563442438" MODIFIED="1264948180028" TEXT="Do nothing" VSHIFT="37">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
<icon BUILTIN="forward"/>
</node>
</node>
</node>
</node>
</node>
<node CREATED="1264899600057" HGAP="109" ID="Freemind_Link_1673926711" MODIFIED="1265674268591" POSITION="left" TEXT="Framework Shutdown" VSHIFT="-211">
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
</node>
<node CREATED="1264899613699" HGAP="107" ID="Freemind_Link_680737216" MODIFIED="1265674266550" POSITION="right" TEXT="Framework Initialized" VSHIFT="72">
<arrowlink COLOR="#ff0000" DESTINATION="Freemind_Link_956260808" ENDARROW="Default" ENDINCLINATION="166;151;" ID="Freemind_Arrow_Link_1026116603" STARTARROW="None" STARTINCLINATION="238;227;"/>
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
</node>
<node CREATED="1264899616049" HGAP="103" ID="Freemind_Link_956260808" MODIFIED="1265674267552" POSITION="left" TEXT="Framework Running" VSHIFT="154">
<arrowlink COLOR="#ff0000" DESTINATION="Freemind_Link_1673926711" ENDARROW="Default" ENDINCLINATION="244;11;" ID="Freemind_Arrow_Link_808801244" STARTARROW="None" STARTINCLINATION="244;11;"/>
<font BOLD="true" NAME="SansSerif" SIZE="16"/>
</node>
</node>
</map>
