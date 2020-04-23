using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Color = DocumentFormat.OpenXml.Wordprocessing.Color;

namespace VenditaVeicoliDLLProject
{
    class OpenXMLTools
    {
        int i = 1;

        private void addHeading1Style(MainDocumentPart mainPart, string colore, string font, string fontSize, bool isBold)
        {
            // we have to set the properties
            RunProperties rPr = new RunProperties();
            Color color = new Color() { Val = colore };
            RunFonts rFont = new RunFonts();
            rFont.Ascii = font;
            rPr.Append(color);
            rPr.Append(rFont);
            if (isBold)
            {
                rPr.Append(new Bold());
            }
            rPr.Append(new FontSize() { Val = fontSize });

            Style style = new Style();
            style.StyleId = "MyHeading" + i;
            style.Append(new Name() { Val = "My Heading " + i });
            style.Append(rPr);

            // we have to add style that we have created to the StylePart
            StyleDefinitionsPart stylePart = mainPart.AddNewPart<StyleDefinitionsPart>();
            stylePart.Styles = new Styles();
            stylePart.Styles.Append(style);
            stylePart.Styles.Save();
            i++;
        }

        private Paragraph createHeading(string content, int nHeader)
        {
            Paragraph heading = new Paragraph();
            Run r = new Run();
            Text t = new Text(content);
            ParagraphProperties pp = new ParagraphProperties();
            // we set the style
            pp.ParagraphStyleId = new ParagraphStyleId() { Val = "MyHeading" + nHeader };
            // we set the alignement
            pp.Justification = new Justification() { Val = JustificationValues.Center };
            heading.Append(pp);
            r.Append(t);
            heading.Append(r);
            return heading;
        }

        private Paragraph createParagraphWithStyles(bool isBold, bool isItalic, bool isUnderlined, string colore, string testo)
        {
            ParagraphProperties pp = new ParagraphProperties();
            pp.Justification = new Justification() { Val = JustificationValues.Center };

            //*******PARAGRAFO 2******
            Paragraph p = new Paragraph();
            p.Append(pp);

            Run r = new Run();
            RunProperties rp = new RunProperties();
            if (isBold)
            {
                rp.Bold = new Bold();
            }
            if (isItalic)
            {
                rp.Italic = new Italic();
            }
            if (isUnderlined)
            {
                rp.Underline = new Underline() { Val = DocumentFormat.OpenXml.Wordprocessing.UnderlineValues.Single };
            }
            rp.Color = new Color() { Val = colore };
            r.Append(rp);
            Text t = new Text(testo) { Space = SpaceProcessingModeValues.Preserve };
            r.Append(t);
            p.Append(r);

            ////BOLD
            //Run r2 = new Run();
            //RunProperties rp2 = new RunProperties();
            //rp2.Bold = new Bold();
            ////Always add properties first
            //r2.Append(rp2);
            //Text t2 = new Text("grassetto - ") { Space = SpaceProcessingModeValues.Preserve };
            //r2.Append(t2);
            //p.Append(r2);

            ////ITALIC
            //Run r4 = new Run();
            //RunProperties rp4 = new RunProperties();
            //rp4.Italic = new Italic();
            ////Always add properties first
            //r4.Append(rp4);
            //Text t4 = new Text("italico - ") { Space = SpaceProcessingModeValues.Preserve };
            //r4.Append(t4);
            //p.Append(r4);

            ////ITALIC, BOLD AND UNDERLINE
            //Run r6 = new Run();
            //RunProperties rp6 = new RunProperties();
            //rp6.Italic = new Italic();
            //rp6.Bold = new Bold();
            //rp6.Underline = new Underline() { Val = DocumentFormat.OpenXml.Wordprocessing.UnderlineValues.Single };
            ////Always add properties first
            //r6.Append(rp6);
            //Text t6 = new Text("italico grassetto e sottolineato - ") { Space = SpaceProcessingModeValues.Preserve };
            //r6.Append(t6);
            //p.Append(r6);

            ////COLORE ROSSO
            //Run r8 = new Run();
            //RunProperties rp8 = new RunProperties();
            //rp8.Color = new Color() { Val = "FF0000" };
            ////Always add properties first
            //r8.Append(rp8);
            //Text t8 = new Text("rosso ") { Space = SpaceProcessingModeValues.Preserve };
            //r8.Append(t8);
            //p.Append(r8);

            return p;
        }
    }
}
