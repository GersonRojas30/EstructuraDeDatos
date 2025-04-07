namespace GestionCine
{
    public class NodoSede
    {
        public string sede;
        public int prioridad;  // Campo para la prioridad
        public NodoSede sgte;

        // Constructor sin prioridad
        public NodoSede(string sede)
        {
            this.sede = sede;
            this.sgte = null;
            this.prioridad = 0;  // Valor predeterminado de prioridad
        }

        // Constructor con prioridad
        public NodoSede(string sede, int prioridad)
        {
            this.sede = sede;
            this.prioridad = prioridad;
            this.sgte = null;
        }
    }
}
