namespace GestionCine
{
    public class NodoSede
    {
        public string sede;
        public int prioridad;  
        public NodoSede sgte;
        public NodoSede(string sede)
        {
            this.sede = sede;
            this.sgte = null;
            this.prioridad = 0;  
        }
        public NodoSede(string sede, int prioridad)
        {
            this.sede = sede;
            this.prioridad = prioridad;
            this.sgte = null;
        }
    }
}
