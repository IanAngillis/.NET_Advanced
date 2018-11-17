using System;
using System.Collections.Generic;
using System.Windows;
using Payables.Data;

namespace WpfDisplayInvoicesDue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                //TODO: retrieve invoices due from data layer
                //Wat we nu ook doen met de data, de UI-laag lijdt er niet onder. We moeten dan alleen de klasse InvoiceRepository aanpassen
                var invoices = InvoiceRepository.GetInvoicesDue();

                //TODO: show a message box when no invoiced are due and close the application        
                if (invoices.Count > 0)
                {
                    this.DataContext = invoices;
                }
                else
                {
                    MessageBox.Show("No invoices due");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                Close();
            }
        }
    }
}
