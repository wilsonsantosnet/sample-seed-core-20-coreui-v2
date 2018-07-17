using Common.Gen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.Gen
{
    public class ConfigContext
    {
        #region Config Contexts

        private Context ConfigContextSeed()
        {
            var contextName = "Seed";

            return new Context
            {

                ConnectionString = ConfigurationManager.ConnectionStrings["Seed"].ConnectionString,

                Namespace = "Seed",
                ContextName = contextName,
                ShowKeysInFront = false,
                LengthBigField = 250,
                OverrideFiles = true,
                UseRouteGuardInFront = true,

                OutputClassDomain = ConfigurationManager.AppSettings[string.Format("outputClassDomain{0}", contextName)],
                OutputClassInfra = ConfigurationManager.AppSettings[string.Format("outputClassInfra{0}", contextName)],
                OutputClassDto = ConfigurationManager.AppSettings[string.Format("outputClassDto{0}", contextName)],
                OutputClassApp = ConfigurationManager.AppSettings[string.Format("outputClassApp{0}", contextName)],
                OutputClassApi = ConfigurationManager.AppSettings[string.Format("outputClassApi{0}", contextName)],
                OutputClassFilter = ConfigurationManager.AppSettings[string.Format("outputClassFilter{0}", contextName)],
                OutputClassSummary = ConfigurationManager.AppSettings[string.Format("outputClassSummary{0}", contextName)],
                OutputAngular = ConfigurationManager.AppSettings["OutputAngular"],
                OutputClassSso = ConfigurationManager.AppSettings["OutputClassSso"],
                OutputClassCrossCustingAuth = ConfigurationManager.AppSettings["OutputClassCrossCustingAuth"],

                Arquiteture = ArquitetureType.DDD,
                CamelCasing = true,
                MakeFront = true,
                AlertNotFoundTable = true,
                MakeToolsProfile = true,
                TwoCols = true,
                DisabledCamelCasingException = true,

                Routes = new List<RouteConfig> {
                    new RouteConfig{ Route = "{ path: 'sampledash',  canActivate: [AuthGuard], loadChildren: './main/sampledash/sampledash.module#SampleDashModule' }" }
                },

                TableInfo = new UniqueListTableInfo
                {
                   new TableInfo { TableName = "SampleStandart", MakeDomain = true, MakeApp = true, MakeDto = true, MakeCrud = true, MakeApi= true, MakeSummary = true , MakeFront= true },
                   new TableInfo { TableName = "Sample", MakeDomain = true, MakeApp = true, MakeDto = true, MakeCrud = true, MakeApi= true, MakeSummary = true , MakeFront= true , FieldsConfig =  new List<FieldConfig>{
                       new FieldConfig
                       {
                           Name = "SampleId",
                           Group = new Group("Dados Basicos","fa fa-file"),
                           ShowFieldIsKey = true,
                           GroupComponent = new GroupComponent("Sample Standart","fa fa-plus-circle","<app-samplestandart></app-samplestandart>","samplestandart"),
                           Attributes = new List<string>{ "[datafilters]=\"{AttributeBehavior:'withoutchild'}\"" },
                           Order =1

                       },
                       new FieldConfig
                       {
                           Name = "Name",
                           Group = new Group("Dados Basicos","fa fa-file"),
                           Order =2
                       },
                        new FieldConfig
                        {
                           Name = "Valor",
                           Group = new Group("Dados Basicos","fa fa-file"),
                           Attributes = new List<string>{"maskm" },
                           Order =3

                        }

                   },
                   GroupComponent = new List<GroupComponent> {
                    new GroupComponent("Sample Detail","fa fa-users","<app-sampledetail [parentIdValue]='vm.model.sampleId' [parentIdField]=\"'sampleId'\" [isParent]=\"'true'\" <#fieldItemsNavHeadShow#> ></app-sampledetail>"),
                    new GroupComponent("Sample Product","fa fa-tasks","<app-sampleproduct [parentIdValue]='vm.model.sampleId' [parentIdField]=\"'sampleId'\" [isParent]=\"'true'\" <#fieldItemsNavHeadShow#> ></app-sampleproduct>"),
                    },
                   },
                   new TableInfo { TableName = "SampleDetail", MakeDomain = true, MakeApp = true, MakeDto = true, MakeCrud = true, MakeApi= true, MakeSummary = true , MakeFront= true, },
                   new TableInfo { TableName = "SampleType", MakeDomain = true, MakeApp = true, MakeDto = true, MakeCrud = true, MakeApi= true, MakeSummary = true , MakeFront= true, },
                   new TableInfo { TableName = "Product", MakeDomain = true, MakeApp = true, MakeDto = true, MakeCrud = true, MakeApi= true, MakeSummary = true , MakeFront= true, },
                   new TableInfo { ClassName = "SampleDash", MakeFront = true, MakeFrontBasic = true , Scaffold = false, UsePathStrategyOnDefine = false },
                   new TableInfo { TableName = "SampleProduct", MakeDomain = true, MakeApp = true, MakeDto = true, MakeCrud = true, MakeApi= true, MakeSummary = true , MakeFront= true , FieldsConfig = new List<FieldConfig>
                   {
                       new FieldConfig {
                           Name = "sampleId",
                           ShowFieldIsKey = true
                       },
                       new FieldConfig {
                           Name = "productId",
                           ShowFieldIsKey = true,
                           ColSize = 12

                       }

                   } },

                }
            };
        }



        public IEnumerable<Context> GetConfigContext()
        {

            return new List<Context>
            {

                ConfigContextSeed(),

            };

        }

        #endregion
    }
}
