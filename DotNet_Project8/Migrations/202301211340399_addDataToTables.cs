namespace DotNet_Project8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataToTables : DbMigration
    {
        public override void Up()
        {

            //Departments
            Sql("insert Departments values('Accts')");
            Sql("insert Departments values('Sales')");
            Sql("insert Departments values('Mkt')");
           

            //Designations
            Sql("insert Designations values('PM')");
            Sql("insert Designations values('TL')");
            Sql("insert Designations values('Prog.')");
        }
        
        public override void Down()
        {
        }
    }
}
