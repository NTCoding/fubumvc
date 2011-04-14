﻿using FubuCore;
using FubuMVC.Spark.Tokenization.Parsing;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Spark.Tests.Tokenization.Parsing
{
    public class ViewModelTypeParserTester
    {
        private readonly IViewModelTypeParser _parser;
        public ViewModelTypeParserTester()
        {
            var extractor = new ElementNodeExtractor();

            _parser = new ViewModelTypeParser(extractor);
        }

        [Test]
        public void when_no_view_model_is_present_null_is_returned()
        {
            var content = 
                Templates.UseMaster.ToFormat("Fubu") + 
                Templates.UseNamespace.ToFormat("A.B.C") +
                Templates.Content.ToFormat("parsing");
            
            _parser.Parse(content).ShouldBeNull();
        }

        [Test]
        public void when_view_model_is_present_type_name_is_returned()
        {
            var content = 
                Templates.UseMaster.ToFormat("Spark") +
                Templates.ViewdataModel.ToFormat(GetType().FullName);

            _parser.Parse(content).ShouldEqual(GetType());
        }   
      
        [Test]
        public void when_multiple_viewdata_is_present_model_is_parsed()
        {
            var content =
                Templates.ViewdataModel.ToFormat(GetType().FullName);

            // Add template for viewdata

            // check that model is found.
        }
    }
}