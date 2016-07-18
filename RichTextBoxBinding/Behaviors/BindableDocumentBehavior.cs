using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interactivity;

namespace RichTextBoxBinding.Behaviors
{
    public class BindableDocumentBehavior : Behavior<RichTextBox>
    {
        public FlowDocument Document
        {
            get { return (FlowDocument)GetValue(DocumentProperty); }
            set { SetValue(DocumentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Document.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.Register(
                "Document", 
                typeof(FlowDocument), 
                typeof(BindableDocumentBehavior), 
                new PropertyMetadata(null, DocumentChanged));


        public bool IsOneWay
        {
            get { return (bool)GetValue(IsOneWayProperty); }
            set { SetValue(IsOneWayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOneWay.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOneWayProperty =
            DependencyProperty.Register(
                "IsOneWay", 
                typeof(bool), 
                typeof(BindableDocumentBehavior), 
                new PropertyMetadata(true));

        private static void DocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((BindableDocumentBehavior)d).DocumentChanged();
        }

        protected override void OnAttached()
        {
            this.AssociatedObject.LostFocus += this.RithTextBox_LostFocus;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.LostFocus -= this.RithTextBox_LostFocus;
        }
        private void RithTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!this.IsOneWay)
            {
                this.Document = this.AssociatedObject.Document;
            }
        }

        private void DocumentChanged()
        {
            this.AssociatedObject.Document = this.Document;
        }
    }
}
