using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1WebAPI.Contracts
{
    public class ApiRoutes
    {
        public const string Root = "api/[controller]";

        public static class Course
        {
            public const string GetAll = Root;

            public const string Get = Root + "/{courseId}";

            public const string Create = Root;

            public const string Delete = Root + "/{courseId}";

            public const string Update = Root + "/{courseId}";

        }
    }
}
