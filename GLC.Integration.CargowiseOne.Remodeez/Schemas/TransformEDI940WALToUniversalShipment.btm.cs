namespace GLC.Integration.CargowiseOne.Remodeez.Schemas {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.EDI940.EDI940Xml", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.EDI940.EDI940Xml))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment))]
    public sealed class TransformEDI940WALToUniversalShipment : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s1 s0 s2 userCSharp"" version=""1.0"" xmlns:ns0=""http://www.cargowise.com/Schemas/Universal/2011/11"" xmlns:s0=""http://schemas.microsoft.com/Edi/X12ServiceSchema"" xmlns:s1=""http://schemas.microsoft.com/BizTalk/EDI/X12/2006/InterchangeXML"" xmlns:s2=""http://schemas.microsoft.com/BizTalk/EDI/X12/2006"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"" xmlns:ScriptNS0=""http://schemas.microsoft.com/BizTalk/2003/ScriptNS0"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s1:X12InterchangeXml"" />
  </xsl:template>
  <xsl:template match=""/s1:X12InterchangeXml"">
    <xsl:variable name=""var:v1"" select=""userCSharp:StringConcat(&quot;GDS&quot;)"" />
    <xsl:variable name=""var:v2"" select=""userCSharp:StringConcat(&quot;US&quot;)"" />
    <!--<xsl:variable name=""var:v3"" select=""userCSharp:StringConcat(&quot;GLCGDSTRN&quot;)"" />-->
    <!--PROD Value-->
    <xsl:variable name=""var:v3"" select=""userCSharp:StringConcat(&quot;GLCGDSLAX&quot;)"" />
    <xsl:variable name=""var:v4"" select=""userCSharp:StringConcat(&quot;GLC&quot;)"" />
    <!--<xsl:variable name=""var:v5"" select=""userCSharp:StringConcat(&quot;TRN&quot;)"" />-->
    <!--PROD Value-->
    <xsl:variable name=""var:v5"" select=""userCSharp:StringConcat(&quot;GDS&quot;)"" />
    <xsl:variable name=""var:v6"" select=""userCSharp:StringConcat(&quot;WarehouseOrder&quot;)"" />
    <ns0:UniversalShipment>
      <ns0:Shipment>
        <ns0:DataContext>
          <ns0:Company>
            <ns0:Code>
              <xsl:value-of select=""$var:v1"" />
            </ns0:Code>
            <ns0:Country>
              <ns0:Code>
                <xsl:value-of select=""$var:v2"" />
              </ns0:Code>
            </ns0:Country>
          </ns0:Company>
          <ns0:DataProvider>
            <xsl:value-of select=""$var:v3"" />
          </ns0:DataProvider>
          <ns0:EnterpriseID>
            <xsl:value-of select=""$var:v4"" />
          </ns0:EnterpriseID>
          <ns0:ServerID>
            <xsl:value-of select=""$var:v5"" />
          </ns0:ServerID>
          <ns0:DataTargetCollection>
            <ns0:DataTarget>
              <ns0:Type>
                <xsl:value-of select=""$var:v6"" />
              </ns0:Type>
            </ns0:DataTarget>
          </ns0:DataTargetCollection>
        </ns0:DataContext>

        <!--<ns0:GoodsDescription>
                <xsl:value-of select=""/*[local-name()='X12InterchangeXml' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006/InterchangeXML']/*[local-name()='FunctionalGroup' and namespace-uri()='']/*[local-name()='TransactionSet' and namespace-uri()='']/*[local-name()='X12_00401_940' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006']/*[local-name()='LXLoop1' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006']/*[local-name()='W01Loop1' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006']/*[local-name()='G69' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006']/*[local-name()='G6901' and namespace-uri()='']"" />
        </ns0:GoodsDescription>-->


        <ns0:LocalProcessing>
          <xsl:for-each select=""FunctionalGroup/TransactionSet/s2:X12_00401_940/s2:G62"">
            <xsl:if test=""G6201='02'"">
              <ns0:DeliveryRequiredBy>
                <xsl:value-of select=""userCSharp:DateimeConversion(G6202/text())"" />
              </ns0:DeliveryRequiredBy>
            </xsl:if>
          </xsl:for-each>
        </ns0:LocalProcessing>

        <ns0:Order>
          <ns0:OrderNumber>
            <xsl:value-of select=""FunctionalGroup/TransactionSet/s2:X12_00401_940/s2:W05/W0502/text()"" />
          </ns0:OrderNumber>
          <ns0:ClientReference>
            <xsl:value-of select=""FunctionalGroup/TransactionSet/s2:X12_00401_940/s2:W05/W0503/text()"" />
          </ns0:ClientReference>
          <xsl:variable name=""cntW01"" select=""/*[local-name()='X12InterchangeXml' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006/InterchangeXML']/*[local-name()='FunctionalGroup' and namespace-uri()='']/*[local-name()='TransactionSet' and namespace-uri()='']/*[local-name()='X12_00401_940' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006']/*[local-name()='W76' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006']/*[local-name()='W7601' and namespace-uri()='']""/>
          <ns0:TotalUnits>
            <xsl:value-of select=""concat($cntW01,'.00')""/>
          </ns0:TotalUnits>
          <!--<ns0:TransportReference>
            <xsl:value-of select=""/*[local-name()='X12InterchangeXml' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006/InterchangeXML']/*[local-name()='FunctionalGroup' and namespace-uri()='']/*[local-name()='TransactionSet' and namespace-uri()='']/*[local-name()='X12_00401_940' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006']/*[local-name()='LXLoop1' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006']/*[local-name()='W01Loop1' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006']/*[local-name()='N9_2' and namespace-uri()='http://schemas.microsoft.com/BizTalk/EDI/X12/2006']/*[local-name()='N902' and namespace-uri()='']""/>
          </ns0:TransportReference>-->
          <xsl:variable name=""var:v8"" select=""userCSharp:StringConcat(&quot;ORD&quot;)"" />
          <ns0:Type>
            <ns0:Code>ORD</ns0:Code>
            <ns0:Description>ORDER</ns0:Description>
          </ns0:Type>
          <xsl:variable name=""var:v9"" select=""userCSharp:StringConcat(&quot;CHN&quot;)"" />
          <ns0:Warehouse>
            <ns0:Code>
              <xsl:value-of select=""$var:v9"" />
            </ns0:Code>
          </ns0:Warehouse>
          <ns0:OrderLineCollection>
            <xsl:variable name=""var:v10"" select=""userCSharp:StringConcat(&quot;Complete&quot;)"" />
            <xsl:attribute name=""Content"">
              <xsl:value-of select=""$var:v10"" />
            </xsl:attribute>
            <xsl:for-each select=""FunctionalGroup/TransactionSet/s2:X12_00401_940/s2:LXLoop1"">
              <xsl:variable name=""var:v7"" select=""position()"" />
              <xsl:for-each select=""s2:W01Loop1"">
                <xsl:for-each select=""s2:W01"">
                  <ns0:OrderLine>
                    <ns0:LineNumber>
                      <xsl:value-of select=""$var:v7"" />
                    </ns0:LineNumber>
                    <ns0:OrderedQty>
                      <xsl:value-of select=""W0101/text()"" />
                    </ns0:OrderedQty>
                    <ns0:OrderedQtyUnit>
                      <ns0:Code>
                        <xsl:text>UNT</xsl:text>
                      </ns0:Code>
                    </ns0:OrderedQtyUnit>
                    <ns0:Product>
                      <ns0:Code>
                        <xsl:value-of select=""W0107/text()"" />
                      </ns0:Code>
                    </ns0:Product>
            <ns0:CustomizedFieldCollection>
            <ns0:CustomizedField>
              <ns0:Key>BuyerPartNumber</ns0:Key>
              <ns0:DataType>String</ns0:DataType>
              <ns0:Value>
                <xsl:value-of select=""../s2:W01/W0105/text()"" />
              </ns0:Value>
            </ns0:CustomizedField>
            <ns0:CustomizedField>
              <ns0:Key>UPCCODE</ns0:Key>
              <ns0:DataType>String</ns0:DataType>
              <ns0:Value>
                <xsl:value-of select=""../s2:W01/W0103/text()"" />
              </ns0:Value>
            </ns0:CustomizedField>
              </ns0:CustomizedFieldCollection>
                  </ns0:OrderLine>
                </xsl:for-each>
              </xsl:for-each>
            </xsl:for-each>
        </ns0:OrderLineCollection>
        </ns0:Order>

        <CustomizedFieldCollection>
          <xsl:for-each select=""FunctionalGroup/TransactionSet/s2:X12_00401_940/s2:N9"">
            <xsl:if test=""N901/text()='23'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>N9*23</Key>
                <Value>
                  <xsl:value-of select=""N902/text()"" />
                </Value>
              </CustomizedField>
            </xsl:if>
            <xsl:if test=""N901/text()='CR'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>N9*CR</Key>
                <Value>
                  <xsl:value-of select=""N902/text()"" />
                </Value>
              </CustomizedField>
            </xsl:if>
            <xsl:if test=""N901/text()='DP'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>N9*DP</Key>
                <Value>
                  <xsl:value-of select=""N902/text()"" />
                </Value>
              </CustomizedField>
            </xsl:if>
            <xsl:if test=""N901/text()='IA'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>N9*IA</Key>
                <Value>
                  <xsl:value-of select=""N902/text()"" />
                </Value>
              </CustomizedField>
            </xsl:if>
              <xsl:if test=""N901/text()='AN'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>N9*AN</Key>
                <Value>
                  <xsl:value-of select=""N902/text()"" />
                </Value>
              </CustomizedField>
            </xsl:if>
            <xsl:if test=""N901/text()='CO'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>N9*CO</Key>
                <Value>
                  <xsl:value-of select=""N902/text()"" />
                </Value>
              </CustomizedField>
            </xsl:if>
            <xsl:if test=""N901/text()='PD'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>N9*PD</Key>
                <Value>
                  <xsl:value-of select=""N902/text()"" />
                </Value>
              </CustomizedField>
            </xsl:if>
          </xsl:for-each>
                    <xsl:for-each select=""FunctionalGroup/TransactionSet/s2:X12_00401_940/s2:N1Loop1"">
            <xsl:if test=""s2:N1/N101/text()='ST'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>N1*04</Key>
                <Value>
                  <xsl:value-of select=""s2:N1/N104/text()"" />
                </Value>
              </CustomizedField>
            </xsl:if>
            </xsl:for-each>
          <xsl:for-each select=""FunctionalGroup/TransactionSet/s2:X12_00401_940/s2:G62"">
            <xsl:if test=""G6201/text()='04'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>G62*04 PURCHASE ORDER DATE</Key>
                <Value>
                  <xsl:value-of select=""userCSharp:DateimeConversion(G6202/text())"" />
                </Value>
              </CustomizedField>
            </xsl:if>
            <xsl:if test=""G6201/text()='01'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>G62*01 CANCEL AFTER DATE</Key>
                <Value>
                  <xsl:value-of select=""userCSharp:DateimeConversion(G6202/text())"" />
                </Value>
              </CustomizedField>
            </xsl:if>
              <xsl:if test=""G6201/text()='37'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>G62*37 SHIP NOT BEFORE DATE</Key>
                <Value>
                  <xsl:value-of select=""userCSharp:DateimeConversion(G6202/text())"" />
                </Value>
              </CustomizedField>
            </xsl:if>
            <xsl:if test=""G6201/text()='38'"">
              <CustomizedField>
                <DataType>String</DataType>
                <Key>G62*38 SHIP NOT LATER THAN DATE</Key>
                <Value>
                  <xsl:value-of select=""userCSharp:DateimeConversion(G6202/text())"" />
                </Value>
              </CustomizedField>
            </xsl:if>
          </xsl:for-each>
          <xsl:for-each select=""FunctionalGroup/TransactionSet/s2:X12_00401_940/s2:W66"">
            <CustomizedField>
              <DataType>String</DataType>
              <Key>W6605*Routing</Key>
              <Value>
                <xsl:value-of select=""W6605/text()"" />
              </Value>
            </CustomizedField>
          </xsl:for-each>

        </CustomizedFieldCollection>

        <ns0:OrganizationAddressCollection>
          <xsl:for-each select=""FunctionalGroup/TransactionSet/s2:X12_00401_940/s2:N1Loop1"">
            <xsl:variable name=""var:v12"" select=""string(../s2:W66/W6610/text())"" />
            <xsl:variable name=""var:v13"" select=""string(../s2:W66/W6605/text())"" />
            <xsl:variable name=""var:v15"" select=""userCSharp:LogicalEq(string(s2:N1/N101/text()) , &quot;ST&quot;)"" />
            <xsl:variable name=""varv20"" select=""string(s2:N1/N101/text())"" />
            <xsl:variable name=""varv21"" select=""string(userCSharp:LogicalEq($varv20 , &quot;SF&quot;))"" />
            <!--<xsl:if test=""$varv20='SF'"">-->
              <ns0:OrganizationAddress>
                <ns0:AddressType>ConsignorDocumentaryAddress</ns0:AddressType>                
                <ns0:OrganizationCode>REMODEUS</ns0:OrganizationCode>
              </ns0:OrganizationAddress>
            <!--</xsl:if>-->
            <xsl:if test=""$varv20='ST'"">
              <ns0:OrganizationAddress>
                <ns0:AddressType>ConsigneeAddress</ns0:AddressType>
                <ns0:Address1>
                  <xsl:value-of select=""s2:N3/N301/text()"" />
                </ns0:Address1>
                <ns0:Address2>
                  <xsl:value-of select=""s2:N3/N302/text()"" />
                </ns0:Address2>
                <ns0:AddressOverride>true</ns0:AddressOverride>
                <ns0:City>
                  <xsl:value-of select=""s2:N4/N401/text()"" />
                </ns0:City>
                <ns0:State>
                  <xsl:value-of select=""s2:N4/N402/text()""/>
                </ns0:State>
                <ns0:CompanyName>
                  <xsl:value-of select=""s2:N1/N102/text()"" />
                </ns0:CompanyName>
                <ns0:Country>
                  <ns0:Code>
                    <xsl:if test=""s2:N4/N404"">
                      <xsl:value-of select=""s2:N4/N404/text()"" />
                    </xsl:if>
                  </ns0:Code>
                </ns0:Country>
                <ns0:Postcode>
                  <xsl:value-of select=""s2:N4/N403/text()"" />
                </ns0:Postcode>
              </ns0:OrganizationAddress>
            </xsl:if>
          </xsl:for-each>
        </ns0:OrganizationAddressCollection>
      </ns0:Shipment>
    </ns0:UniversalShipment>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp"">
    <![CDATA[
  public string StringConcat(string param0) { return param0; }
public string DateimeConversion(string strin) { strin = strin.Substring(0, 4) + ""-"" + strin.Substring(4, 2) + ""-"" + strin.Substring(6, 2); DateTime strdatetime = new DateTime(); strdatetime = DateTime.Parse(strin); strin = strdatetime.ToString(""yyyy-MM-ddTHH:mm:ss""); return strin; }
public bool LogicalEq(string val1, string val2) { bool ret = false; double d1 = 0; double d2 = 0; if (IsNumeric(val1, ref d1) && IsNumeric(val2, ref d2)) { ret = d1 == d2; } else { ret = String.Compare(val1, val2, StringComparison.Ordinal) == 0; } return ret; }
public string ChkSCACt(string strWO10, string strWO05) { if (strWO10 == ""FDXIP"" || strWO10 == ""FDXIE"" || strWO10 == ""FDXIG"" || strWO10 == ""FXND"" || strWO10 == ""FDEG"" || strWO10 == ""FXPO"" || strWO10 == ""FXSP"" || strWO10 == ""FDES"" || strWO10 == ""FDXES"" || strWO10 == ""FDXSO"" || strWO10 == ""FDXHD"") { return ""FEDEXPUS""; } else if (strWO10 == ""UPSG"") { return ""UPSUS2""; } else if (strWO10 == ""UPS3D"" || strWO10 == ""UPSNDS"" || strWO10 == ""UPS2D"" || strWO10 == ""UPSNDA"") { return ""UPSAIRUS""; } else if (strWO10 == ""LTL"") { return strWO05; } else { if (strWO05 != """") { return """"; } else { return strWO10; } } return """"; }
public string ChkSCAC(string strWO10, string strWO05) { if (strWO10 == ""UPS3D"" || strWO10 == ""UPSNDS"" || strWO10 == ""UPS2D"" || strWO10 == ""UPSNDA"" || strWO10 == ""UPSSG"" || strWO10 == ""FDXIP"" || strWO10 == ""FDXIE"" || strWO10 == ""FDXIG"" || strWO10 == ""FXND"" || strWO10 == ""FDEG"" || strWO10 == ""FXPO"" || strWO10 == ""FXSP"" || strWO10 == ""FDES"" || strWO10 == ""FDXES"" || strWO10 == ""FDXSO"" || strWO10 == ""FDXHD"") { return """"; } else if (strWO10 == ""LTL"") { return strWO05; } else { if (strWO10 != """") { return strWO10; } else { return strWO05; } } return """"; }
public string ChkSCACCity(string strWO10, string strWO05) { if (strWO10 != ""UPS3D"" || strWO10 != ""UPSNDS"" || strWO10 != ""UPS2D"" || strWO10 != ""UPSNDA"" || strWO10 != ""UPSSG"" || strWO10 != ""FDXIP"" || strWO10 != ""FDXIE"" || strWO10 != ""FDXIG"" || strWO10 != ""FXND"" || strWO10 != ""FDEG"" || strWO10 != ""FXPO"" || strWO10 != ""FXSP"" || strWO10 != ""FDES"" || strWO10 != ""FDXES"" || strWO10 != ""FDXSO"" || strWO10 != ""FDXHD"") { return """"; } else { if (strWO05 != """") { return """"; } } return """"; }
public string ChkSCACCountry(string strWO10, string strWO05) { if (strWO10 != ""UPS3D"" || strWO10 != ""UPSNDS"" || strWO10 != ""UPS2D"" || strWO10 != ""UPSNDA"" || strWO10 != ""UPSSG"" || strWO10 != ""FDXIP"" || strWO10 != ""FDXIE"" || strWO10 != ""FDXIG"" || strWO10 != ""FXND"" || strWO10 != ""FDEG"" || strWO10 != ""FXPO"" || strWO10 != ""FXSP"" || strWO10 != ""FDES"" || strWO10 != ""FDXES"" || strWO10 != ""FDXSO"" || strWO10 != ""FDXHD"") { return """"; } else { if (strWO05 != """") { return ""US""; } } return """"; }
public bool IsNumeric(string val) { if (val == null) { return false; } double d = 0; return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d); }
public bool IsNumeric(string val, ref double d) { if (val == null) { return false; } return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d); }
  ]]>
  </msxsl:script>
</xsl:stylesheet>
";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.EDI940.EDI940Xml";
        
        private const global::GLC.Integration.CargowiseoneInboundCommon.Schemas.EDI940.EDI940Xml _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
        
        private const global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.EDI940.EDI940Xml";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
                return _TrgSchemas;
            }
        }
    }
}
