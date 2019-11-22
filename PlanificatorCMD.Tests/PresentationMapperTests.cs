//using PlanificatorCMD.Core;
//using PlanificatorCMD.Utils;
//using PlanificatorCMD.Verbs;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;

//namespace PlanificatorCMD.Tests
//{
//    public class PresentationMapperTests
//    {
//        [Fact]
//        public void MapToPresentationTag_ShoulReturnCorrectList()
//        {
//            var verb = new AddPresentationVerb() { Title = "Gala", LongDescription = "Gala de seara astazi", ShortDescription = "Gala de seara", Tags = "#GALA" };
//            var expected = new List<PresentationTag>()
//            {
//                new PresentationTag() {  Presentation = new Presentation ()
//                {
//                     Title = "Gala",
//                     ShortDescription = "Gala de seara",
//                     LongDescription = "Gala de seara astazi"
//                }
//                ,
//                Tag = new Tag ()  { TagName = "#GALA" }
//                }
//            };

//            var mapper = new PresentationMapper();

//            var act = mapper.MapToPresentationTag(verb);

//            Assert.Equal(expected.ToString(), act.ToString());
//        }
//    }
//}