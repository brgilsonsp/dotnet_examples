using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientWhioutSSL
{
    public class MethodHttp
    {
        public string LabelMethod { get; }

        public TypeHttpMethod ValueMathod { get; }

        public MethodHttp(TypeHttpMethod typeHttpMethod)
        {
            this.LabelMethod = typeHttpMethod.ToString();
            this.ValueMathod = typeHttpMethod;
        }
    }
}
