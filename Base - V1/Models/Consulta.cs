using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base___V1.Models
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public int InVacunas { get; set; }
        public int InQuintuple { get; set; }
        public int InTripleFelina { get; set; }
        public int InParvovirus { get; set; }
        public int InRabia { get; set; }
        public int InGiardia { get; set; }
        public int InBordetella { get; set; }
        public int InLeucemia { get; set; }
        public string InOtra { get; set; }
        public int InDesparacitacion { get; set; }
        public string FechaDesparacitacion { get; set; }
        public string MedicamentoDesparacitacion { get; set; }
        public int InControlGarrapata { get; set; }
        public string FechaControlGarrapata { get; set; }
        public string MedicamentoControlGarrapata { get; set; }
        public string TiempoMascota { get; set; }
        public string OtrasMascotas { get; set; }
        public string DietaAlimenticia { get; set; }
        public int AccesoCalle { get; set; }
        public int ContactoEnfermos { get; set; }
        public string EnfermedadesAnt { get; set; }
        public string Habitat { get; set; }
        public string SintomasObs { get; set; }
        public string MedAdmCasa { get; set; }
        public string StAspecto { get; set; }
        public string StLesiones { get; set; }
        public string StAlopecia { get; set; }
        public string StParasitos { get; set; }
        public string SmeMovimeinto { get; set; }
        public string SdApetito { get; set; }
        public string SdIngestoAgua { get; set; }
        public int SdVomito { get; set; }
        public string SdVomitoFrecuencia { get; set; }
        public string SdAspecto { get; set; }
        public int SdDefeca { get; set; }
        public string SdDefecaFrecuencia { get; set; }
        public string SdColor { get; set; }
        public string SdAspectoDefeca { get; set; }
        public int SdEstreñimiento { get; set; }
        public int SdFlatulencia { get; set; }
        public int SdDeglucion { get; set; }
        public string SrTos { get; set; }
        public string SrTipo { get; set; }
        public string SrDisnea { get; set; }
        public string SrEstornudos { get; set; }
        public string SrDescargaNasal { get; set; }
        public string ScFF { get; set; }
        public string ScClanosis { get; set; }
        public string ScTosNocturna { get; set; }
        public string SuOrina { get; set; }
        public string SuCastrado { get; set; }
        public int SuCruzadoRaza { get; set; }
        public int SuGestante { get; set; }
        public string SuPsudociesis { get; set; }
        public string SuUltimoCelo { get; set; }
        public string SuUltimoParto { get; set; }
        public string SuDescargaPreVa { get; set; }
        public string SnComportamiento { get; set; }
        public string SnIncoordinacion { get; set; }
        public string SnDismetria { get; set; }
        public int SnGolpePrevio { get; set; }
        public int SnRespondeLlamado { get; set; }
        public string SnOjos { get; set; }
        public string SnSecrecion { get; set; }
        public string SnCeguera { get; set; }
        public string SnOidos { get; set; }
        public string SnSeRasca { get; set; }
        public string SnMalOlor { get; set; }
        public string SnEscucha { get; set; }
        public string SnParasitos { get; set; }
        public string SnDescarga { get; set; }
        public string SnAfectado { get; set; }
        public int IdMascota { get; set; }
        public string FechaRealizado { get; set; }
        public string MotivoConsulta { get; set; }
    }
}
