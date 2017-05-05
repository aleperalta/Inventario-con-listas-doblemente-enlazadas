using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_listaDoblementeEnlazada
{
    class Inventario
    {
        Producto ultimo, primero, encontrado, temp;

        public Inventario()
        {
            primero = null;
        }

        public void agregar(Producto nuevoP)
        {
            if (primero == null)
            {
                primero = nuevoP;
                ultimo = nuevoP;
            }
            else
            {
                nuevoP.anterior = ultimo;
                ultimo.siguiente = nuevoP;
                ultimo = nuevoP;
            }
        }

        public void agregarEnInicio(Producto prodEnInicio)
        {
            if (primero == null)
            {
                primero = prodEnInicio;
                ultimo = prodEnInicio;
            }
            else
            {
                primero.anterior = prodEnInicio;
                prodEnInicio.siguiente = primero;
                primero = prodEnInicio;
            }
        }

        public void insertar(Producto prodAInsertar, int posicion)
        {
            if (posicion == 1)
                agregarEnInicio(prodAInsertar);
            else
            {
                int vcont = 2;
                temp = primero;

                while (vcont < posicion)
                {
                    temp = temp.siguiente;
                    vcont++;
                }

                prodAInsertar.siguiente = temp.siguiente;
                prodAInsertar.anterior = temp;
                temp.siguiente.anterior = prodAInsertar;
                temp.siguiente = prodAInsertar;
            }
        }

        public Producto buscar(int codigoP)
        {
            temp = primero;
            encontrado = null;

            while (encontrado == null && temp != null)
                if (temp.codigo == codigoP)
                    encontrado = temp;
                else
                    temp = temp.siguiente;

            return encontrado;
        }

        public bool eliminar(int codigoP)
        {
            if (buscar(codigoP) != null)
            {
                if (encontrado == primero)
                    eliminarPrimero();
                else
                {
                    encontrado.anterior.siguiente = encontrado.siguiente;

                    if (encontrado.siguiente != null)
                        encontrado.siguiente.anterior = encontrado.anterior;
                    else
                        ultimo = encontrado.anterior;
                }

                return true;
            }
            else
                return false;
        }

        public bool eliminarPrimero()
        {
            if (primero == null)
                return false;
            else
            {
                primero = primero.siguiente;
                primero.anterior = null;
                return true;
            }
        }

        public bool eliminarUltimo()
        {
            if (ultimo == null)
                return false;
            else
            {
                ultimo = ultimo.anterior;
                ultimo.siguiente = null;
                return true;
            }
        }

        public string mostrar()
        {
            string vProducto = "";
            temp = primero;

            while (temp != null)
            {
                vProducto += temp.ToString() + Environment.NewLine;
                temp = temp.siguiente;
            }

            return vProducto;
        }

        public string inverso()
        {
            return mostrarInverso(primero);
        }

        private string mostrarInverso(Producto temp)
        {
            string vProducto = "";

            if (temp.siguiente != null)
                vProducto = mostrarInverso(temp.siguiente);

            vProducto += temp.ToString() + Environment.NewLine;
            return vProducto;
        }
    }
}
