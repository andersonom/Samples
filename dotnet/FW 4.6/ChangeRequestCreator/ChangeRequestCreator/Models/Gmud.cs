using OpenXmlPowerTools;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ChangeRequestCreator.Models
{
    public class Gmud
    {
        public Gmud(string templatePath, string[] selectedServers, string ownerName, string description, string version)
        {
            if (String.IsNullOrEmpty(templatePath))
                throw new Exception("Template can't be null");
            if(selectedServers == null)         
                throw new Exception("No Servers Selected");
            
            Id = 234;
            TemplatePath = templatePath;
            Version = version;
            CreationDate = DateTime.UtcNow;
            Description = description;
            OwnerName = ownerName;
            SourcePath = "\\\\Server\\Files\\GMUD\\InProgress\\";
            HomologPath = "\\\\Server\\WEBSITES\\Homolog\\ABC\\Intranet\\";
            SelectedServers = selectedServers;
        } 

        public int Id { get; set; }
        public string TemplatePath { get; set; }
        public string Systems { get; set; }
        public string Servers { get; set; }
        public string Version { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public string PreUpdate { get; set; }
        public string SourcePath { get; set; }
        public string ProductionPath { get; set; }
        public string HomologPath { get; set; } 
        public string[] SelectedServers { get; set; }
        //public string ServerName { get; set; } //Currently Using Random
        //public string SystemName { get; set; } //Currently Using Random
        private string[] GenericSystems = new string[] { "SystemABC", "SystemDEF", "SystemHIJ" };
        private string[] GenericServers = new string[] { "ServerABC", "ServerDEF", "ServerDEF" };

        private XElement GenerateXML()
        {
            Random rnd = new Random();

            return new XElement("Gmud",
                                    new XElement("Id", this.Id),
                                    new XElement("Version", this.Version),
                                    new XElement("CreationDate", this.CreationDate.ToShortDateString()),
                                    new XElement("Description", this.Description),
                                    new XElement("OwnerName", this.OwnerName),
                                     new XElement("Itens",
                                         Enumerable.Repeat("", SelectedServers.Length)
                                            .Select((x, y) =>
                                            new XElement("Item",
                                                new XAttribute("ServerType", SelectedServers[y]),
                                                new XElement("PreUpdate", string.Empty),
                                                new XElement("ServerName", GenericServers[rnd.Next(GenericServers.Length)]),
                                                new XElement("SystemName", GenericSystems[rnd.Next(GenericSystems.Length)]),
                                                new XElement("SourcePath", this.SourcePath),
                                                new XElement("HomologPath", this.HomologPath),
                                                new XElement("ProductionPath", this.ProductionPath)                                                
                                                  )
                                                )
                                              )
                                            );
        }

        private WmlDocument GenerateDoc(XElement dataXML)
        {
            FileInfo docTemplate = new FileInfo(this.TemplatePath);
            WmlDocument wmlDoc = new WmlDocument(docTemplate.FullName);

            bool templateError;
            WmlDocument wmlAssembledDoc = DocumentAssembler.AssembleDocument(wmlDoc, dataXML, out templateError);

            //wmlAssembledDoc.SaveAs(documentoGerado.FullName);

            //if (templateError)
            //{
            //    throw new Exception("Errors in template.",
            //        new Exception(String.Format("Check {0} to determinate the error in template.", wmlAssembledDoc.FileName)));
            //} 

            return wmlAssembledDoc;
        }

        public WmlDocument GetDoc()
        {
            XElement dataXML = GenerateXML();

            WmlDocument wmlAssembledDoc = GenerateDoc(dataXML);

            return wmlAssembledDoc;
        }
    }
}