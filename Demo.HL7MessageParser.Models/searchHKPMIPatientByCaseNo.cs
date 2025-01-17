﻿using System.Xml.Serialization;

namespace Demo.HL7MessageParser.Models
{
    [XmlRoot(ElementName = "searchHKPMIPatientByCaseNo")]
    public class SearchHKPMIPatientByCaseNo
    {
        [XmlElement(ElementName = "hospitalCode")]
        public string HospitalCode { get; set; }

        [XmlElement(ElementName = "caseNo")]
        public string CaseNo { get; set; }
    }

    [XmlRoot(ElementName = "searchHKPMIPatientByCaseNoResponse")]
    public class SearchHKPMIPatientByCaseNoResponse
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
                    xmlns.Add("ns2", "http://webservice.pas.ha.org.hk/");
                }
                return xmlns;
            }
            set { xmlns = value; }
        }

        [XmlElement(ElementName = "PatientDemoEnquiryResult", Namespace = "")]
        public PatientDemoEnquiry PatientDemoEnquiry { get; set; }
    }
}