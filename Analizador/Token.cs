using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador
{
    class Token
    {
        public enum Tipo
        {
            NUMERO_ENTERO,
            NUMERO_DECIMAL,
            MONEDA,
            IDENTIFICADOR

        }

        private Tipo TipoToken;
        private String valor;

        public Token(Tipo tipotoken, String valor)
        {
            this.TipoToken = tipotoken;
            this.valor = valor;
        }

        public String Getvalor()
        {
            return valor;
        }

        public String GetTipo()
        {
            switch (TipoToken)
            {
                case Tipo.IDENTIFICADOR:
                    return "Identificador";
                case Tipo.MONEDA:
                    return "Moneda";
                case Tipo.NUMERO_DECIMAL:
                    return "Numero Decimal";
                case Tipo.NUMERO_ENTERO:
                    return "Numero Entero";
                default:
                    return "Desconocido";





            }
        }

    }
}

