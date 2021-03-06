﻿using Blog.Application;
using Blog.Contracts.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        // nasz DI container, który wykorzystamy do tworzenia powiązań
        private IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
           kernel.Bind<IUserService>().To<UserService>();
           kernel.Bind<IPostService>().To<PostService>();
           kernel.Bind<ICategoryService>().To<CategoryService>();
           kernel.Bind<ICommentService>().To<CommentService>();


        }

        protected override IController GetControllerInstance(
            RequestContext reqCtx, Type controllerType)
        {
            return kernel.Get(controllerType) as IController;
        }
    }
}