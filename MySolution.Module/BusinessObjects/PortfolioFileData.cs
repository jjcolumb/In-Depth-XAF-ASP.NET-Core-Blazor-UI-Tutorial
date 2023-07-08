using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MySolution.Module.BusinessObjects
{
    public class PortfolioFileData : FileAttachmentBase
    {
        public PortfolioFileData(Session session) : base(session) { }
        private Resume resume;
        [Association("Resume-PortfolioFileData")]
        [RuleRequiredField(DefaultContexts.Save)]

        public Resume Resume
        {
            get { return resume; }
            set { SetPropertyValue(nameof(Resume), ref resume, value); }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            documentType = DocumentType.Unknown;
        }
        private DocumentType documentType;
        public DocumentType DocumentType
        {
            get { return documentType; }
            set { SetPropertyValue(nameof(DocumentType), ref documentType, value); }
        }
    }
    public enum DocumentType
    {
        SourceCode = 1, Tests = 2, Documentation = 3,
        Diagrams = 4, ScreenShots = 5, Unknown = 6
    };
}