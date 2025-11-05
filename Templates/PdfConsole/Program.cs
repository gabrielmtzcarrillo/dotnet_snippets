using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;

using PdfDocument = QuestPDF.Fluent.Document;

QuestPDF.Settings.License = LicenseType.Community;

PdfDocument PdfDocument = PdfDocument.Create(
    container =>
    {
        container.Page(page =>
        {
            page.Size(PageSizes.Letter);
            page.Margin(2.5f, Unit.Centimetre);
            page.DefaultTextStyle(x => x.FontSize(12));

            //https://www.questpdf.com/api-reference/text.html
            page.Content().Text("Red big text").FontColor("#F00").FontSize(24);
        });


    }
);

byte[] bytes = PdfDocument.GeneratePdf();

File.WriteAllBytes("output.pdf", bytes);
