namespace AM.Condo.Tasks
{
    using System.IO;

    using Microsoft.Build.Utilities;
    using Newtonsoft.Json;
    using Xunit;

    using AM.Condo.IO;

    [Class(nameof(GetNodeScripts))]
    public class GetNodeScriptsTest
    {
        [Fact]
        [Priority(2)]
        [Purpose(PurposeType.Integration)]
        public void Execute_WithValidProject_Succeeds()
        {
            using (var temp = new TemporaryPath())
            {
                // arrange
                var project = new
                {
                    name = "test",
                    version = "1.0.0",
                    description = "",
                    main = "index.js",
                    scripts = new
                    {
                        test = "echo this is a test script",
                        ci = "echo this is a ci script"
                    },
                    author = "automotiveMastermind",
                    license = "MIT"
                };

                var expected = new[] { "test", "ci" };

                var path = temp.Combine("package.json");

                using (var writer = File.CreateText(path))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(writer, project);
                    writer.Flush();
                }

                var item = new TaskItem(path);

                var engine = MSBuildMocks.CreateEngine();

                var instance = new GetNodeScripts
                {
                    Project = item,
                    BuildEngine = engine
                };

                // act
                var result = instance.Execute();

                // assert
                Assert.True(result);
            }
        }
    }
}