using Prism.Mvvm;
using System.Linq;
using System.Windows.Documents;

namespace RichTextBoxBinding.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private FlowDocument document;

        public FlowDocument Document
        {
            get { return this.document; }
            set { this.SetProperty(ref this.document, value); this.OnPropertyChanged(nameof(OutputDocument)); }
        }

        public FlowDocument OutputDocument
        {
            get
            {
                if (this.Document == null) { return null; }
                var r = new FlowDocument();
                foreach (var paragraph in this.Document.Blocks.OfType<Paragraph>())
                {
                    var copyParagraph = new Paragraph();
                    foreach (var run in paragraph.Inlines.OfType<Run>())
                    {
                        var copyRun = new Run
                        {
                            Text = run.Text,
                            Foreground = run.Foreground,
                            Background = run.Background,
                            FontSize = run.FontSize,
                        };
                        copyParagraph.Inlines.Add(copyRun);
                    }
                    r.Blocks.Add(copyParagraph);
                }
                return r;
            }
        }
    }
}
