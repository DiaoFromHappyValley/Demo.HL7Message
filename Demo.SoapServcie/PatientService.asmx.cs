﻿using Demo.HL7MessageParser.Common;
using Demo.HL7MessageParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Demo.SoapServcie
{
    /// <summary>
    /// Summary description for PatientService
    /// </summary>
    [WebService(Namespace = "http://webservice.pas.ha.org.hk/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class PatientService : System.Web.Services.WebService
    {
        public WorkContextSoapHeader WorkContext { get; set; }


        [WebMethod]
        [SoapHeader("WorkContext", Direction = SoapHeaderDirection.InOut)]
        [SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare)]
        public SearchHKPMIPatientByCaseNoResponse searchHKPMIPatientByCaseNo(SearchHKPMIPatientByCaseNo caseNo)
        {
            WorkContext = new WorkContextSoapHeader();

            return new SearchHKPMIPatientByCaseNoResponse { PatientDemoEnquiry = SoapProcessHelper.DoProcess() };
        }
    }

    public class AuthHeader : SoapHeader
    {
        public string UserName;
        public string Password;

    }

    [XmlRoot(ElementName = "WorkContext", Namespace = "http://oracle.com/weblogic/soap/workarea/")]
    public class WorkContextSoapHeader : SoapHeader
    {
        private XmlSerializerNamespaces xmlns;

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns
        {
            get
            {
                if (xmlns == null)
                {
                    xmlns = new XmlSerializerNamespaces();
                    xmlns.Add("work", "http://oracle.com/weblogic/soap/workarea/");
                }
                return xmlns;
            }
            set { xmlns = value; }
        }
    }
}
