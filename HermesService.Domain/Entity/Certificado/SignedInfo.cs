﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.Certificado
{
    public class SignedInfo
    {
        /// <summary>
        ///     XS03 - Grupo do Método de Canonicalização
        /// </summary>
        public CanonicalizationMethod CanonicalizationMethod { get; set; }

        /// <summary>
        ///     XS05 - Grupo do Método de Assinatura
        /// </summary>
        public SignatureMethod SignatureMethod { get; set; }

        /// <summary>
        ///     XS07 - Grupo Reference
        /// </summary>
        //public Reference Reference { get; set; }
    }
}
