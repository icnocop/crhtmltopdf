﻿// <copyright file="FooterRightTests.cs" company="HtmlToPdf">
// Copyright (c) HtmlToPdf. All rights reserved.
// </copyright>

namespace HtmlToPdfTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DotLiquid;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pathoschild.NaturalTimeParser.Extensions.DotLiquid;
    using UglyToad.PdfPig.Content;

    /// <summary>
    /// Footer Right Tests
    /// </summary>
    [TestClass]
    public class FooterRightTests
    {
        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Asserts that passing footer-right with a page placeholder inserts a page number in the footer.
        /// </summary>
        /// <param name="footerRightCommandLineArgument">The footer right command line argument.</param>
        /// <param name="expectedFooterTextTemplate">The expected footer text template.</param>
        [TestMethod]
        [DataRow("[page]", "1")]
        [DataRow("[date]", "{{ 'today' | as_date | date:'M/dd/yyyy' }}")]
        [DataRow("[title]", "The title of the test page")]
        [DataRow("[webpage]", "{{url}}")]
        public void FooterRight_WithVariable_InsertsPageNumberInFooter(string footerRightCommandLineArgument, string expectedFooterTextTemplate)
        {
            HtmlToPdfRunner runner = new HtmlToPdfRunner();

            string html = @"
<html>
  <head>
    <title>The title of the test page</title>
  </head>
  <body>
   Test Page
  </body>
</html>";

            using (TempHtmlFile htmlFile = new TempHtmlFile(html))
            {
                var uri = new Uri(htmlFile.FilePath);

                Dictionary<string, object> dictionary = new Dictionary<string, object>
                {
                    { "url", uri.AbsoluteUri }
                };
                Hash hash = Hash.FromDictionary(dictionary);
                Template.RegisterFilter(typeof(NaturalDateFilter));
                Template template = Template.Parse(expectedFooterTextTemplate);
                string expectedFooterText = template.Render(hash);

                using (TempPdfFile pdfFile = new TempPdfFile(this.TestContext))
                {
                    string commandLine = $"--margin-bottom 10mm --footer-right {footerRightCommandLineArgument} \"{htmlFile.FilePath}\" \"{pdfFile.FilePath}\"";
                    HtmlToPdfRunResult result = runner.Run(commandLine);
                    Assert.AreEqual(0, result.ExitCode, result.Output);

                    using (var pdfDocument = UglyToad.PdfPig.PdfDocument.Open(pdfFile.FilePath))
                    {
                        Assert.AreEqual(1, pdfDocument.NumberOfPages);
                        Page page = pdfDocument.GetPage(1);
                        IEnumerable<Word> words = page.GetWords();
                        Assert.IsTrue(words.Count() >= 3);
                        Assert.AreEqual("Test Page", $"{words.ElementAt(0)} {words.ElementAt(1)}");
                        Assert.AreEqual(expectedFooterText.ToLower(), string.Join(" ", words.Skip(2).Select(x => x.Text.ToLower())));
                    }
                }
            }
        }

        /// <summary>
        /// Asserts that passing footer-right with a page placeholder inserts a page number in the footer in multiple pages.
        /// </summary>
        [TestMethod]
        public void FooterRight_WithPage_InsertsPageNumberInFooterInMultiplePages()
        {
            HtmlToPdfRunner runner = new HtmlToPdfRunner();

            string html1 = @"
<html>
  <head>
  </head>
  <body>
   Page 1
  </body>
</html>";

            string html2 = @"
<html>
  <head>
  </head>
  <body>
   Page 2
  </body>
</html>";

            using (TempHtmlFile htmlFile1 = new TempHtmlFile(html1))
            {
                using (TempHtmlFile htmlFile2 = new TempHtmlFile(html2))
                {
                    using (TempPdfFile pdfFile = new TempPdfFile(this.TestContext))
                    {
                        string commandLine = $"--footer-right [page] \"{htmlFile1.FilePath}\" \"{htmlFile2.FilePath}\" \"{pdfFile.FilePath}\"";
                        HtmlToPdfRunResult result = runner.Run(commandLine);
                        Assert.AreEqual(0, result.ExitCode, result.Output);

                        using (var pdfDocument = UglyToad.PdfPig.PdfDocument.Open(pdfFile.FilePath))
                        {
                            Assert.AreEqual(2, pdfDocument.NumberOfPages);
                            Page page1 = pdfDocument.GetPage(1);
                            IEnumerable<Word> words = page1.GetWords();
                            Assert.AreEqual(3, words.Count());
                            Assert.AreEqual("Page 1", $"{words.ElementAt(0)} {words.ElementAt(1)}");
                            Assert.AreEqual("1", words.Last().Text); // the page number

                            Page page2 = pdfDocument.GetPage(2);
                            words = page2.GetWords();
                            Assert.AreEqual(3, words.Count());
                            Assert.AreEqual("Page 2", $"{words.ElementAt(0)} {words.ElementAt(1)}");
                            Assert.AreEqual("2", words.Last().Text); // the page number
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Asserts that passing footer-right with footer-style page inserts the footer style in all pages.
        /// </summary>
        [TestMethod]
        public void FooterRight_WithFooterStyle_InsertsFooterStyleInAllPages()
        {
            HtmlToPdfRunner runner = new HtmlToPdfRunner();

            string html1 = @"
<html>
  <head>
  </head>
  <body>
   Page 1
  </body>
</html>";

            string html2 = @"
<html>
  <head>
  </head>
  <body>
   Page 2
  </body>
</html>";

            using (TempHtmlFile htmlFile1 = new TempHtmlFile(html1))
            {
                using (TempHtmlFile htmlFile2 = new TempHtmlFile(html2))
                {
                    using (TempPdfFile pdfFile = new TempPdfFile(this.TestContext))
                    {
                        string commandLine = $"--footer-right [page] --footer-style display:none; \"{htmlFile1.FilePath}\" \"{htmlFile2.FilePath}\" \"{pdfFile.FilePath}\"";
                        HtmlToPdfRunResult result = runner.Run(commandLine);
                        Assert.AreEqual(0, result.ExitCode, result.Output);

                        using (var pdfDocument = UglyToad.PdfPig.PdfDocument.Open(pdfFile.FilePath))
                        {
                            Assert.AreEqual(2, pdfDocument.NumberOfPages);
                            Page page1 = pdfDocument.GetPage(1);
                            IEnumerable<Word> words = page1.GetWords();
                            Assert.AreEqual(2, words.Count());
                            Assert.AreEqual("Page 1", $"{words.ElementAt(0)} {words.ElementAt(1)}");

                            Page page2 = pdfDocument.GetPage(2);
                            words = page2.GetWords();
                            Assert.AreEqual(2, words.Count());
                            Assert.AreEqual("Page 2", $"{words.ElementAt(0)} {words.ElementAt(1)}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Asserts that passing footer-right with CSS to hide the footer on the first page does not show the footer on the first page.
        /// </summary>
        [TestMethod]
        public void FooterRight_WithCssToHideFooterOnFirstPage_DoesNotShowFooterOnFirstPage()
        {
            HtmlToPdfRunner runner = new HtmlToPdfRunner();

            string html1 = @"
<html>
  <head>
    <style type=""text/css"" media=""print"">
            #footer-template {display:none}
    </style>
  </head>
  <body>
   Page 1
  </body>
</html>";

            string html2 = @"
<html>
  <head>
  </head>
  <body>
   Page 2
  </body>
</html>";

            using (TempHtmlFile htmlFile1 = new TempHtmlFile(html1, this.TestContext))
            {
                using (TempHtmlFile htmlFile2 = new TempHtmlFile(html2, this.TestContext))
                {
                    using (TempPdfFile pdfFile = new TempPdfFile(this.TestContext))
                    {
                        string commandLine = $"--footer-right [page] \"{htmlFile1.FilePath}\" \"{htmlFile2.FilePath}\" \"{pdfFile.FilePath}\"";
                        HtmlToPdfRunResult result = runner.Run(commandLine);
                        Assert.AreEqual(0, result.ExitCode, result.Output);

                        using (var pdfDocument = UglyToad.PdfPig.PdfDocument.Open(pdfFile.FilePath))
                        {
                            Assert.AreEqual(2, pdfDocument.NumberOfPages);
                            Page page1 = pdfDocument.GetPage(1);
                            IEnumerable<Word> words = page1.GetWords();
                            Assert.AreEqual(2, words.Count());
                            Assert.AreEqual("Page 1", $"{words.ElementAt(0)} {words.ElementAt(1)}");

                            Page page2 = pdfDocument.GetPage(2);
                            words = page2.GetWords();
                            Assert.AreEqual(3, words.Count());
                            Assert.AreEqual("Page 2", $"{words.ElementAt(0)} {words.ElementAt(1)}");
                            Assert.AreEqual("2", words.Last().Text); // the page number
                        }
                    }
                }
            }
        }
    }
}
