<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:var="http://schemas.microsoft.com/BizTalk/2003/var" exclude-result-prefixes="msxsl var" version="1.0" xmlns:ns0="http://www.cargowise.com/Schemas/Universal/2011/11">
  <xsl:output omit-xml-declaration="yes" method="xml" version="1.0" />
  <xsl:template match="/">
    <xsl:apply-templates select="/ns0:UniversalInterchange" />
  </xsl:template>
  <xsl:template match="/ns0:UniversalInterchange">
    <ns0:UniversalEvent>
      <xsl:copy-of select="ns0:Body/@*" />
      <xsl:copy-of select="ns0:Body/ns0:UniversalEvent/*" />
    </ns0:UniversalEvent>
  </xsl:template>
</xsl:stylesheet>