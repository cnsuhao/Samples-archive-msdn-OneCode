<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:import href="TeamFoundation.xsl"/>
    <!-- Common TeamSystem elements -->
    <xsl:template match="CheckOutEvent">
        <head>
            <!-- Pull in the command style settings -->
            <xsl:call-template name="style">
            </xsl:call-template>
        </head>
        <body>
            <div class="Title">
                CheckOut Event
            </div>
            <div>
                <xsl:value-of select="UserName"/>
                <xsl:text> is trying to check out following items:</xsl:text>
            </div>
            <div>
                <xsl:apply-templates select="Items"/>
            </div>
        </body>
    </xsl:template>
    <xsl:template match="CheckOutEvent/Items">
        <xsl:apply-templates select="string"/>
    </xsl:template>
    <xsl:template match="CheckOutEvent/Items/string">
        <xsl:value-of select="node()" />
        <br/>
    </xsl:template>
</xsl:stylesheet>