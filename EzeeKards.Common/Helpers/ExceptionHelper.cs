using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Common.Helpers
{
    public static class ExceptionHelper
    {
        public static string GetExceptionMessage(Exception ex)
        {
            return !String.IsNullOrEmpty(ex?.InnerException?.InnerException?.Message)
                                    ? ex.InnerException.InnerException.Message
                                    : !String.IsNullOrEmpty(ex?.InnerException?.Message)
                                        ? ex.InnerException.Message
                                        : !String.IsNullOrEmpty(ex?.Message)
                                            ? ex.Message
                                            : String.Empty;
        }

        public static string GetInternalServerError(Exception ex)
        {
            return $"Internal server error: {GetExceptionMessage(ex)}";
        }
    }
}
