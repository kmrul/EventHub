// <auto-generated />
namespace EventHub.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddCanceledToEvent : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddCanceledToEvent));
        
        string IMigrationMetadata.Id
        {
            get { return "201906091034568_AddCanceledToEvent"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}