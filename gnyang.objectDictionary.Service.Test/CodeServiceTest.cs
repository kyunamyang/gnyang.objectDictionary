using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using gnyang.objectDictionary.Service.Interface;
using gnyang.objectDictionary.ViewModel;
using Moq;

namespace gnyang.objectDictionary.Service.Test
{
    [TestClass]
    public class CodeServiceTest
    {
        [TestMethod]
        public void GetClassDefinition_ReturnString_Test()
        {
            // arrange
            var m = new CodeViewModel {
                Name = "Sample",
                Fields = new List<FieldViewModel>
                {
                    new FieldViewModel{ Type = "int", Name = "Age" },
                }
            };
            var mockService = new Mock<ICodeService<CodeViewModel>>();
            //CodeService service = new CodeService(mockService.Object);
            CodeService service = new CodeService();

            // act
            var actual = service.GetClassDefinition(m);

            // assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.GetType() == typeof(string));
        }


        [TestMethod]
        public void GetClassDefinition_SingleProperty_Test()
        {
            // arrange
            var expected = "public class Sample { public int Age { get; set; } }";
            var m = new CodeViewModel {
                Name = "Sample",
                Fields = new List<FieldViewModel>
                {
                    new FieldViewModel{ Type = "int", Name = "Age" },
                }
            };
            //var mockService = new Mock<ICodeService<CodeViewModel>>();
            //CodeService service = new CodeService(mockService.Object);
            CodeService service = new CodeService();

            // act
            var actual = service.GetClassDefinition(m);

            // assert
            actual = ReplaceCodeWhitespace(actual);
            Assert.AreEqual(expected, actual);  
        }

        [TestMethod]
        public void GetClassDefinition_MultiProperty_Test()
        {
            // arrange
            var expected = "public class Sample { public int Age { get; set; } public string Name { get; set; } public string Phone { get; set; } }";
            var m = new CodeViewModel {
                Name = "Sample",
                Fields = new List<FieldViewModel>
                {
                    new FieldViewModel{ Type = "int", Name = "Age" },
                    new FieldViewModel{ Type = "string", Name = "Name" },
                    new FieldViewModel{ Type = "string", Name = "Phone" }
                }
            };
            //var mockService = new Mock<ICodeService<CodeViewModel>>();
            //CodeService service = new CodeService(mockService.Object);
            CodeService service = new CodeService();

            // act
            var actual = service.GetClassDefinition(m);

            // assert
            actual = ReplaceCodeWhitespace(actual);
            Assert.AreEqual(expected, actual);
        }

        private string ReplaceCodeWhitespace(string actual)
        {
            return actual.Replace("    ", "")
                .Replace(System.Environment.NewLine, " ")
                .Replace("  ", " ");
        }
    }
}
