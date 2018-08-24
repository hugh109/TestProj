using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using Services;
using Services.Interface;
using Repository;


namespace WebAp
{

    /// <summary>
    /// DI設定檔
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 註冊DI注入物件資料
        /// </summary>
        public static void Register()
        {
            // 容器建立者
            var builder = new ContainerBuilder();

            // 註冊Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            #region Register    
                  
            builder.RegisterType<EmployeesService>().As<IEmployeeService>();
            builder.RegisterType<EmployeesRepository>().As<IEmployeesRepository>();

            //-------------------------------------------------------
            //但用下面二種方式都沒有成功
            //用檔案結尾來註冊
            //// 註冊Services
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //       .Where(t => t.Name.EndsWith("Service"))
            //       .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces();


            //// 這裡 Namespace 來取得所有介面與介面實作
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //          .Where(t => t.Namespace.EndsWith("Repository"))
            //          .AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //          .Where(t => t.Namespace.EndsWith("Services"))
            //           .AsImplementedInterfaces();
            //-------------------------------------------------------
            #endregion

            // 建立容器
            IContainer container = builder.Build();

            // 建立相依解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}