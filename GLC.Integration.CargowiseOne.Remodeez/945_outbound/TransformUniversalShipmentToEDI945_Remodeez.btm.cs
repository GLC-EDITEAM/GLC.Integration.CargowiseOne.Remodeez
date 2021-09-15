namespace GLC.Integration.CargowiseOne.Remodeez._945_outbound {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945", typeof(global::GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945))]
    public sealed class TransformUniversalShipmentToEDI945_Remodeez : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0 userCSharp"" version=""1.0"" xmlns:ns0=""http://schemas.microsoft.com/BizTalk/EDI/X12/2006"" xmlns:s0=""http://www.cargowise.com/Schemas/Universal/2011/11"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:UniversalShipment"" />
  </xsl:template>
  <xsl:template match=""/s0:UniversalShipment"">
   
    <xsl:variable name=""var:v4"" select=""userCSharp:StringConcat(&quot;WH&quot;)"" />
    <xsl:variable name=""var:v5"" select=""userCSharp:StringConcat(&quot;Remodeez c/o GDS&quot;)"" />
    <ns0:X12_00401_945>
      <xsl:variable name=""vartransport"">
        <xsl:value-of select=""s0:Shipment/s0:Order/s0:TransportReference/text()""/>
      </xsl:variable>
      <ns0:W06>
        <W0601>N</W0601>
        <W0602>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:OrderNumber/text()"" />
         </W0602>
        <xsl:for-each select=""s0:Shipment/s0:DataContext"">
          <xsl:for-each select=""s0:EventType"">
            <xsl:variable name=""var:v1"" select=""userCSharp:LogicalEq(string(s0:Code/text()) , &quot;FIN&quot;)"" />
            <xsl:if test=""string($var:v1)='true'"">
              <xsl:variable name=""var:v2"" select=""userCSharp:Getdateformat(../s0:TriggerDate/text())"" />
              <W0603>
                <xsl:value-of select=""$var:v2"" />
              </W0603>
            </xsl:if>
          </xsl:for-each>
        </xsl:for-each>
        <W0606>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:ClientReference/text()"" />  
      </W0606>
       
      </ns0:W06>
      <ns0:N1Loop1>
        <ns0:N1>
          <N101>
            <xsl:value-of select=""$var:v4"" />
          </N101>
          <N102>
            <xsl:value-of select=""$var:v5"" />
          </N102>   
        </ns0:N1>
        <ns0:N3>
          <N301>23647 W EAMES ST</N301>
        </ns0:N3>
        <ns0:N4>
          <N401>CHANNAHON</N401>
          <N402>IL</N402>
          <N403>60410</N403>
          <N404>US</N404>
        </ns0:N4>
        
      </ns0:N1Loop1>

      <xsl:variable name=""varAmazlookup"">
        <xsl:for-each select=""//s0:CustomizedFieldCollection"">
          <xsl:for-each select=""s0:CustomizedField"">
            <xsl:if test=""s0:Value/text()='080ALLREMODEEZ0'"">
              <xsl:value-of select=""s0:Value/text()""/>
            </xsl:if>
          </xsl:for-each>
        </xsl:for-each>
      </xsl:variable>


      <xsl:variable name=""varn904"">
        <xsl:for-each select=""//s0:CustomizedFieldCollection"">
          <xsl:for-each select=""s0:CustomizedField"">
            <xsl:if test=""s0:Key/text()='N1*04'"">             
                  <ns0:N9>
                    <N902>
                      <xsl:value-of select=""s0:Value/text()""/>
                    </N902>
                  </ns0:N9> 
            </xsl:if>
          </xsl:for-each>
        </xsl:for-each>
        
      </xsl:variable>

      
      
      <xsl:for-each select=""s0:Shipment/s0:OrganizationAddressCollection/s0:OrganizationAddress"">
        <xsl:if test=""s0:AddressType/text()='ConsigneeAddress'"">
          <ns0:N1Loop1>
            <ns0:N1>
              <N101>
                <xsl:text>ST</xsl:text>
              </N101>
              <N102>
                <xsl:value-of select=""s0:CompanyName/text()"" />
              </N102>
              <N103>92</N103>
             
              <N104>
                <xsl:value-of select=""$varn904""></xsl:value-of>
              </N104>
              
                </ns0:N1>
            <ns0:N3>
              <N301>
                <xsl:value-of select=""s0:Address1/text()""/>
              </N301>
            </ns0:N3>
            <ns0:N4>
                  <N401>
                    <xsl:value-of select=""s0:City/text()""/>
                  </N401>
                  <N402>
                    <xsl:value-of select=""s0:State/text()""/>
                  </N402>
                  <N403>
                    <xsl:value-of select=""s0:Postcode/text()""/>
                  </N403>              
                  <N404>
                    <xsl:value-of select=""s0:Country/s0:Code/text()""/>
                </N404>
            </ns0:N4>
                      
          </ns0:N1Loop1>
        
        </xsl:if>               
      </xsl:for-each>
      
      <xsl:for-each select=""//s0:CustomizedFieldCollection"">
        <xsl:for-each select=""s0:CustomizedField"">
          <xsl:if test=""s0:Value/text()='080ALLREMODEEZ0'"">         
          <ns0:N1Loop1>
            <ns0:N1>
              <N101>
                <xsl:text>SF</xsl:text>
              </N101>
              <N102>
                <xsl:value-of select=""$var:v5"" />
              </N102>
              <N103>92</N103>

              <N104>
                <xsl:value-of select=""$varn904""></xsl:value-of>
              </N104>
            </ns0:N1>
            <ns0:N3>
              <N301>23647 W EAMES ST</N301>
            </ns0:N3>
            <ns0:N4>
              <N401>CHANNAHON</N401>
              <N402>IL</N402>
              <N403>60410</N403>
              <N404>US</N404>
            </ns0:N4>

          </ns0:N1Loop1>
          </xsl:if>
        </xsl:for-each>
      </xsl:for-each>
      <ns0:N9>
        <N901>BM</N901>
        <N902>
          <xsl:value-of select=""$vartransport""/>
        </N902>

      </ns0:N9>
      
      

      <xsl:for-each select=""//s0:CustomizedFieldCollection"">
        <xsl:for-each select=""s0:CustomizedField"">

          <xsl:if test =""$varAmazlookup='080ALLREMODEEZ0'"">
            <xsl:if test=""s0:Key/text()='N9*BX'"">
              <ns0:N9>
                <N901>BX</N901>
                <xsl:choose>
                  <xsl:when test=""s0:Value/text()!=''"">
                    <N902>
                      <xsl:value-of select=""s0:Value/text()""/>
                    </N902>
                  </xsl:when>
                  <xsl:otherwise>
                    <N902>1234</N902>
                  </xsl:otherwise>
                </xsl:choose>
              </ns0:N9>
            </xsl:if>


          </xsl:if>
          
          <xsl:if test=""s0:Key/text()='N9*DP'"">
            <ns0:N9>
              <N901>DP</N901>
              <xsl:choose>
                  <xsl:when test=""s0:Value/text()!=''"">                    
                      <N902>
                        <xsl:value-of select=""s0:Value/text()""/>
                      </N902>                    
                  </xsl:when>
                <xsl:otherwise>
                    <N902>1234</N902>
                  </xsl:otherwise>
            </xsl:choose>
            </ns0:N9>
          </xsl:if>

          <xsl:if test=""s0:Key/text()='N9*IA'"">
            <ns0:N9>
              <N901>IA</N901>
              <xsl:choose>
                <xsl:when test=""s0:Value/text()!=''"">
                  <N902>
                    <xsl:value-of select=""s0:Value/text()""/>
                  </N902>
                </xsl:when>
                <xsl:otherwise>
                  <N902>1234</N902>
                </xsl:otherwise>
              </xsl:choose>
            </ns0:N9>
          </xsl:if>
          
         <xsl:if test=""s0:Key/text()='N9*CO'"">
           <ns0:N9>
             <N901>CO</N901>
             <xsl:choose>
               <xsl:when test=""s0:Value/text()!=''"">
                 <N902>
                   <xsl:value-of select=""s0:Value/text()""/>
                 </N902>
               </xsl:when>
               <xsl:otherwise>
                 <N902>1234</N902>
               </xsl:otherwise>
             </xsl:choose>
           </ns0:N9>
          </xsl:if>

          <xsl:if test=""s0:Key/text()='N9*23'"">
            <ns0:N9>
              <N901>23</N901>
              <xsl:choose>
                <xsl:when test=""s0:Value/text()!=''"">
                  <N902>
                    <xsl:value-of select=""s0:Value/text()""/>
                  </N902>
                </xsl:when>
                <xsl:otherwise>
                  <N902>1234</N902>
                </xsl:otherwise>
              </xsl:choose>
            </ns0:N9>
          </xsl:if>
        <xsl:if test=""s0:Key/text()='N9*PD'"">
          <ns0:N9>
            <N901>PD</N901>
            <xsl:choose>
              <xsl:when test=""s0:Value/text()!=''"">
                <N902>
                  <xsl:value-of select=""s0:Value/text()""/>
                </N902>
              </xsl:when>
              <xsl:otherwise>
                <N902>1234</N902>
              </xsl:otherwise>
            </xsl:choose>
          </ns0:N9>
          </xsl:if>
        
          <xsl:if test=""s0:Key/text()='N9*AN'"">
            <ns0:N9>
              <N901>AN</N901>
              <xsl:choose>
                <xsl:when test=""s0:Value/text()!=''"">
                  <N902>
                    <xsl:value-of select=""s0:Value/text()""/>
                  </N902>
                </xsl:when>
                <xsl:otherwise>
                  <N902>1234</N902>
                </xsl:otherwise>
              </xsl:choose>
            </ns0:N9>
          </xsl:if>

          <xsl:if test=""s0:Key/text()='N9*CR'"">
            <ns0:N9>
              <N901>CR</N901>
              <xsl:choose>
                <xsl:when test=""s0:Value/text()!=''"">
                  <N902>
                    <xsl:value-of select=""s0:Value/text()""/>
                  </N902>
                </xsl:when>
                <xsl:otherwise>
                  <N902>1234</N902>
                </xsl:otherwise>
              </xsl:choose>
            </ns0:N9>
          </xsl:if>
        </xsl:for-each>
      </xsl:for-each>
      <!--<xsl:variable name=""varDeliverdate"" select=""s0:Shipment/s0:LocalProcessing/s0:DeliveryRequiredBy/text()""/>-->
      <xsl:for-each select=""s0:Shipment/s0:MilestoneCollection/s0:Milestone"">
        
        <xsl:if test=""s0:EventCode/text()='FIN'"">
          <xsl:variable name=""eventdate"">
            <xsl:value-of select=""s0:ActualDate/text()""/>
          </xsl:variable>
          <ns0:G62>
            <G6201>
              <xsl:text>11</xsl:text>
            </G6201>
            
            <G6202>
              <xsl:value-of select=""userCSharp:Getdateformat(s0:ActualDate/text())""/>
            </G6202>
            
          </ns0:G62>

          <xsl:for-each select=""//s0:CustomizedFieldCollection"">
            <xsl:for-each select=""s0:CustomizedField"">
              <xsl:if test=""s0:Value/text()='080ALLREMODEEZ0'"">
                <ns0:G62>
                  <G6201>
                    <xsl:text>02</xsl:text>
                  </G6201>

                  <G6202>
                    <xsl:value-of select=""userCSharp:getadddate($eventdate)""/>
                  </G6202>

                </ns0:G62>
              </xsl:if>
            </xsl:for-each>
          </xsl:for-each>
        </xsl:if>
        
      </xsl:for-each>

     
            <xsl:variable name=""varW2702"">
        <xsl:for-each select=""//s0:AdditionalReferenceCollection"">
          <xsl:for-each select=""s0:AdditionalReference"">
          
          <xsl:if test =""Type/text()='VHN'"">
            <xsl:value-of select=""ReferenceNumber/text()""/>
          </xsl:if>
          </xsl:for-each>
        </xsl:for-each>
        
      </xsl:variable>

      <!--<xsl:for-each select=""s0:Shipment/s0:OrganizationAddressCollection/s0:OrganizationAddress"">
        <xsl:if test=""s0:AddressType/text()='TransportCompanyDocumentaryAddress'"">-->
          <ns0:W27>
            <W2701>
              <xsl:text>M</xsl:text>
            </W2701>
            <W2702>
              <xsl:value-of select=""/*[local-name()='UniversalShipment' and namespace-uri()='http://www.cargowise.com/Schemas/Universal/2011/11']/*[local-name()='Shipment' and namespace-uri()='http://www.cargowise.com/Schemas/Universal/2011/11']/*[local-name()='AdditionalReferenceCollection' and namespace-uri()='http://www.cargowise.com/Schemas/Universal/2011/11']/*[local-name()='AdditionalReference' and namespace-uri()='http://www.cargowise.com/Schemas/Universal/2011/11']/*[local-name()='ReferenceNumber' and namespace-uri()='http://www.cargowise.com/Schemas/Universal/2011/11']""/>
            </W2702>            
          </ns0:W27>
        <!--</xsl:if>
      </xsl:for-each>-->
      <xsl:for-each select=""s0:Shipment/s0:Order/s0:OrderLineCollection/s0:OrderLine"">
        
          <xsl:variable name=""varprodcodelist"" select =""s0:Product/s0:Code/text()""/>

          <xsl:variable name=""varprodcodelist1"" select =""s0:Product/s0:Description/text()""/>
        
          <xsl:variable name =""varctn"" select=""s0:QuantityMet/text()""/>
        <xsl:variable name =""varlxcnt"" select=""userCSharp:getcnt()""/>

          <xsl:variable name=""varVendorvalue"">
            <xsl:for-each select=""s0:CustomizedFieldCollection/s0:CustomizedField"">
              <xsl:if test=""s0:Key='UPCCODE'"">
                <xsl:value-of select=""s0:Value/text()""/>
              </xsl:if>
          </xsl:for-each>
          </xsl:variable>
          <xsl:variable name=""varPartvalue"">
            <xsl:for-each select=""s0:CustomizedFieldCollection/s0:CustomizedField"">
              <xsl:if test=""s0:Key='BuyerPartNumber'"">
                <xsl:value-of select=""s0:Value/text()""/>
              </xsl:if>
            </xsl:for-each>
          </xsl:variable>
          <xsl:for-each select=""//s0:PackingLineCollection"">
            <xsl:for-each select=""s0:PackingLine"">
              <xsl:for-each select=""s0:PackedItemCollection"">
                <xsl:for-each select=""s0:PackedItem"">
                  <!--<xsl:variable name=""varProdcode"" select=""ScriptNS0:GetProdCode(s0:Description/text())""/>-->
                  <xsl:variable name=""varProdcode"" select=""s0:Description/text()""/>
                  <xsl:if test=""$varprodcodelist1=$varProdcode"">
                    <!--<xsl:value-of select=""../../s0:PackType/s0:Code/text()"" />-->
                    <ns0:LXLoop1>
                      <ns0:LX>
                        <LX01>
                          <xsl:value-of select=""$varlxcnt""/>
                        </LX01>
                      </ns0:LX>
          <ns0:MAN>
            <MAN01>GM</MAN01>
            <xsl:if test=""../../s0:ReferenceNumber"">
              <MAN02>
                <xsl:value-of select=""concat('00',../../s0:ReferenceNumber/text())"" />
              </MAN02>

            </xsl:if>
           
          </ns0:MAN>
                  <!--</xsl:if>
                </xsl:for-each>
              </xsl:for-each>
            </xsl:for-each>
          </xsl:for-each>-->

          <!--<xsl:for-each select=""//s0:PackingLineCollection"">
              <xsl:for-each select=""s0:PackingLine"">
                <xsl:for-each select=""s0:PackedItemCollection"">
                  <xsl:for-each select=""s0:PackedItem"">
                    --><!--<xsl:variable name=""varProdcode"" select=""ScriptNS0:GetProdCode(s0:Description/text())""/>--><!--
                    <xsl:variable name=""varProdcode"" select=""s0:Description/text()""/>
                 <xsl:if test=""$varprodcodelist1=$varProdcode"">-->
                   <ns0:W12Loop1>
                      <ns0:W12>
                        <W1201>
                          <xsl:text>CC</xsl:text>
                        </W1201>
                        <!--<xsl:variable name=""varProdcode"" select=""ScriptNS0:GetProdCode(s0:Description/text())""/>-->
                        <!--<xsl:variable name=""varQuantity"" select =""ScriptNS0:Get945convPCE($varProdcode,userCSharp:replacefunc(s0:PackedQuantity/text()))""/>-->
                        <W1202>
                          <xsl:value-of select=""s0:PackedQuantity/text()""/>
                        </W1202>
                        <!--<xsl:variable name=""varw1203"" select=""ScriptNS0:Get945convPCE(../s0:Product/s0:Code/text(),userCSharp:replacefunc(../s0:QuantityMet/text()))""/>-->
                        <W1203>
                          <xsl:value-of select=""s0:PackedQuantity/text()""/>
                        </W1203>
                        <W1204>0</W1204>
                        <xsl:if test=""($varVendorvalue!='') or ($varAmazlookup='080ALLREMODEEZ0')"">
                          <W1205>
                            <xsl:text>UN</xsl:text>
                          </W1205>
                        </xsl:if>
                            <xsl:choose>
                              <xsl:when test=""$varAmazlookup='080ALLREMODEEZ0'"">
                                <W1206>
                                  <xsl:value-of select=""concat('0000',$varprodcodelist)""/>
                                </W1206>
                              </xsl:when>
                              <xsl:otherwise>
                                <W1206>
                                  <xsl:value-of select=""$varVendorvalue""/>
                                </W1206>
                              </xsl:otherwise>
                            </xsl:choose>                       
                         
                       
                       
                        <W1217>
                          <xsl:text>VN</xsl:text>
                        </W1217>
                        <W1218>
                          <xsl:value-of select=""$varprodcodelist""/>
                        </W1218>
                        <xsl:if test=""$varPartvalue!=''"">
                        <W1221>
                          <xsl:text>BP</xsl:text>
                        </W1221>
                       
                          <W1222>
                            <xsl:value-of select=""$varPartvalue""/>
                          </W1222>
                        </xsl:if>
                        
                      </ns0:W12>
                    <!--<ns0:N9_3>
                        <N901>LI</N901>
                          <N902>
                            <xsl:value-of select =""$varProdVal""/>
                    </N902>
                      </ns0:N9_3>-->
                     <!--<xsl:variable name=""varCTNWeight"" select=""ScriptNS0:Get945convPCEWeight($varProdcode,userCSharp:replacefunc(s0:PackedQuantity/text()))""/>-->
                     <!--<xsl:variable name=""varProdcode"" select=""ScriptNS0:GetProdCode(s0:Description/text())""/>
                      <xsl:if test=""$varprodcodelist=$varProdcode"">-->
                                          
                      <!--</xsl:if>-->                       
                    
                    
                    
                    </ns0:W12Loop1>
                  </ns0:LXLoop1>
                     </xsl:if>
                  </xsl:for-each>
                </xsl:for-each>
              </xsl:for-each>
            
            </xsl:for-each>
        
    
      </xsl:for-each>
      <xsl:value-of select=""userCSharp:resetcnt()""/>
      <ns0:W03>
        <xsl:variable name=""vartotalqnt"">
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:TotalUnits/text()""/>
        </xsl:variable>
        <W0301>
          <xsl:value-of select=""s0:Shipment/s0:Order/s0:TotalUnits/text()""/>
        </W0301>
        <W0302>
          <xsl:value-of select=""userCSharp:getcbconversion(s0:Shipment/s0:Order/s0:TotalNetWeightSent/text())""/>
        </W0302>
        <W0303>LB</W0303>
        <xsl:for-each select=""//s0:CustomizedFieldCollection"">
          <xsl:for-each select=""s0:CustomizedField"">
            <xsl:if test=""s0:Value/text()='080ALLREMODEEZ0'"">
              <W0306>
                <xsl:value-of select=""userCSharp:replacefunc($vartotalqnt)""/>
              </W0306>
              <W0307>CT</W0307>
            </xsl:if>
          </xsl:for-each>
        </xsl:for-each>
      </ns0:W03>
      
    </ns0:X12_00401_945>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp"">
    <![CDATA[
    
    public int lxcnt=0;
    
    public int getcnt()
    {
      lxcnt=lxcnt+1;
      return lxcnt;
    }
    
    public void resetcnt()
    {
      lxcnt=0;
      }
    public double getcbconversion(int a)
    {
    double b=0;
      b=a*2.2;
      return b;
      }
    
    public int getdiff(int a1,int a2)
    {
         int a11=a1-a2;
         return a11;
    }
    
    public string replacefunc(string strin)
    {
    strin=strin.Replace("".000"","""");
    return strin;
    }    
    public string Getdateformat(string strin)
    {
           DateTime dt2 = new DateTime();
            dt2 = Convert.ToDateTime(strin);
            strin = dt2.ToString(""yyyyMMdd"");
            return strin;
    }
    
        
    public string getadddate(string strin)
    {
          DateTime dt2 = new DateTime();
            dt2 = Convert.ToDateTime(strin);
            dt2 = dt2.AddDays(2);
            strin = dt2.ToString(""yyyyMMdd"");
            return strin;
            }
    
public bool LogicalEq(string val1, string val2)
{
	bool ret = false;
	double d1 = 0;
	double d2 = 0;
	if (IsNumeric(val1, ref d1) && IsNumeric(val2, ref d2))
	{
		ret = d1 == d2;
	}
	else
	{
		ret = String.Compare(val1, val2, StringComparison.Ordinal) == 0;
	}
	return ret;
}


public string StringConcat(string param0)
{
   return param0;
}


public bool IsNumeric(string val)
{
	if (val == null)
	{
		return false;
	}
	double d = 0;
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}

public bool IsNumeric(string val, ref double d)
{
	if (val == null)
	{
		return false;
	}
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}


]]>
  </msxsl:script>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects>
  <ExtensionObject Namespace=""http://schemas.microsoft.com/BizTalk/2003/ScriptNS0"" AssemblyName=""GLC.Integration.CargowiseOne.CLASSICBRANDS.Utilites, Version=1.0.0.0, Culture=neutral, PublicKeyToken=0a6f121f7d5d0b26"" ClassName=""GLC.Integration.CargowiseOne.CLASSICBRANDS.Utility.Unitconvertfunction"" />
</ExtensionObjects>";
        
        private const string _strSrcSchemasList0 = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
        
        private const global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945";
        
        private const global::GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945 _trgSchemaTypeReference0 = null;
        
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
                _SrcSchemas[0] = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"GLC.Integration.CargowiseOne.CLASSICBRANDS.Schemas.EDI945.X12_00401_945";
                return _TrgSchemas;
            }
        }
    }
}
