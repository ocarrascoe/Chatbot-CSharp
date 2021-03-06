﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.modelos
{
    /// <summary>
    /// En vista que se creó el proyecto con el nombre chatbot, la clase que representaría a este
    /// debido a restricciones del lenguaje por coincidencias de nombre es que 
    /// tuvo que ser llamada de una forma diferente, pero igualmente representativa: 
    /// "Sellerbot" ó Bot Vendedor. 
    /// </summary>
    public class Sellerbot
    {
        /// <summary>
        /// Gets or sets de la personalidad.
        /// </summary>
        /// <value>
        /// El parámetro personalidad representa la personalidad del chatbot,
        /// definiendo así su comportamiento.
        /// </value>
        public int personalidad { get; set; }
        /// <summary>
        /// Gets or sets de evaluaciones.
        /// </summary>
        /// <value>
        /// El parámetro evaluaciones representa las evaluaciones del chatbot,
        /// dada las evaluaciones realizadas por el usuario según el desempeño del chatbot.
        /// </value>
        public int evaluaciones { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sellerbot"/> class.
        /// </summary>
        public Sellerbot(){
            this.personalidad = 1;
            this.evaluaciones = 5;
        }

        /// <summary>
        /// Comienza el dialogo por parte del Chatbot con un mensaje de bienvenida
        /// según el tipo de personalidad que elige el usuario.
        /// </summary>
        /// <param name="personalidad">Personalidad elegida por el usuario a través de
        /// las vistas.</param>
        /// <returns>Devuelve el saludo correspondiente del Chatbot.</returns>
        public String beginDialog(int personalidad)
        {
            int Hora = getHora();
            this.personalidad = personalidad;
            String saludo;
            if (personalidad == 1)
            {
                if (Hora >= 6 && Hora < 12)
                {
                    saludo = "Chatbot: Buenos Dias, ¿Cuál es tu nombre?";
                }
                else if (Hora >= 12 && Hora < 20)
                {
                    saludo = "Chatbot: Buenas Tardes, ¿Cuál es tu nombre?";
                }
                else if (Hora > 20)
                {
                    saludo = "Chatbot: Buenas Noches, ¿Cuál es tu nombre?";
                }
                else
                {
                    saludo = "Chatbot: Buenas, ¿Cuál es tu nombre?";
                }
            }
            else
            {
                saludo = "Chatbot: Buena!, Cómo te llamas?";
            }
            return saludo;
        }

        /// <summary>
        /// Dialogos del chatbot según el último identificador.
        /// </summary>
        /// <param name="respuestaUsuario">Respuesta del usuario.</param>
        /// <param name="identificador">útlimo identificador obtenido del log.</param>
        /// <returns>Devuelve una lista que contiene, en posiciones separadas, los Strings de la respuesta correspondiente al último
        /// identificador y el nuevo último identificador según esa respuesta.</returns>
        public List<String> dialog(String respuestaUsuario, String identificador)
        {
            List<String> mensajes = new List<String>();
            String mensaje;
            String nuevoIdentificador;
            if (Equals("|Nombre|", identificador))
            {
                if (this.personalidad == 1)
                {
                    mensaje = "Chatbot: ¿Cómo estás " + respuestaUsuario + "?";
                    nuevoIdentificador = "|Respuesta1|";
                    mensajes = juntarMensajes(mensaje, nuevoIdentificador);
                }
                if (this.personalidad == 0)
                {
                    mensaje = "Chatbot: ¿Cómo estai " + respuestaUsuario + "?";
                    nuevoIdentificador = "|Respuesta1|";
                    mensajes = juntarMensajes(mensaje, nuevoIdentificador);
                }
            }
            else if (Equals("|Respuesta1|", identificador))
            {
                mensaje = "Chatbot: Oh, bueno. Estos son las marcas/modelos de autos de las homocinéticas que disponemos: 1.-Toyota Rav4, 2.-Renault Duster, 3.-Hyundai Tucson, 4.-Nissan Qashqai, 5.-Nissan Kicks, elija la opción que desea.";
                nuevoIdentificador = "|Respuesta2|";
                mensajes = juntarMensajes(mensaje, nuevoIdentificador);
            }
            else if (Equals("|Respuesta2|", identificador))
            {
                mensaje = "Chatbot: Perfecto, ¿Cuántas querrá?";
                nuevoIdentificador = "|Respuesta3|";
                mensajes = juntarMensajes(mensaje, nuevoIdentificador);
            }
            else if (Equals("|Respuesta3|", identificador))
            {
                mensaje = "Chatbot: Excelente, ¿Desea comprar algo más?";
                nuevoIdentificador = "|Respuesta4|";
                mensajes = juntarMensajes(mensaje, nuevoIdentificador);
            }
            else if (Equals("|Respuesta4|", identificador))
            {
                if (Equals("Sí", respuestaUsuario) || Equals("Si", respuestaUsuario) || Equals("sí", respuestaUsuario) || Equals("si", respuestaUsuario)
                || Equals("Sí, me gustaría comprar algo más", respuestaUsuario) || Equals("Si, me gustaria comprar algo mas", respuestaUsuario)
                || Equals("sí, me gustaría comprar algo más", respuestaUsuario) || Equals("si, me gustaria comprar algo mas", respuestaUsuario))
                {
                    mensaje = "Chatbot: ¡Okey! Estos son las marcas/modelos de autos de las homocinéticas que disponemos: 1.-Toyota Rav4, 2.-Renault Duster, 3.-Hyundai Tucson, 4.-Nissan Qashqai, 5.-Nissan Kicks, elija la opción que desea.";
                    nuevoIdentificador = "|Respuesta2|";
                    mensajes = juntarMensajes(mensaje, nuevoIdentificador);
                }
                else if (Equals("No", respuestaUsuario) || Equals("no", respuestaUsuario) || Equals("No, no me gustaría comprar algo más", respuestaUsuario) || Equals("no, no me gustaria comprar algo mas", respuestaUsuario))
                {
                    mensaje = "Chatbot: ¡Está bien! Todos sus items han sido agregados a su carro.";
                    nuevoIdentificador = "|Listo para Finalizar|";
                    mensajes = juntarMensajes(mensaje, nuevoIdentificador);
                }
                else
                {
                    mensaje = "Chatbot: Lo lamento, no logro entenderte, ¿Podrías repetirlo?";
                    nuevoIdentificador = "|Respuesta4|";
                    mensajes = juntarMensajes(mensaje, nuevoIdentificador);
                }
            }
            return mensajes;
        }

        /// <summary>
        /// Junta en una lista el mensaje dado por el chatbot y el nuevo identificador final.
        /// </summary>
        /// <param name="mensaje">Mensaje de respuesta del Chatbot.</param>
        /// <param name="nuevoIdentificador">Corresponde a un String que representa el nuevo identificador final.</param>
        /// <returns>Devuelve una lista con el mensaje dado por el chatbot y el nuevo identificador final.</returns>
        public List<String> juntarMensajes(String mensaje, String nuevoIdentificador)
        {
            List<String> mensajes = new List<string>();
            mensajes.Add(mensaje);
            mensajes.Add(nuevoIdentificador);
            return mensajes;
        }

        /// <summary>
        /// Termina el dialogo por parte del Chatbot con un mensaje de despedida
        /// según el tipo de personalidad que elige el usuario.
        /// </summary>
        /// <returns>Devuelve el saludo correspondiente del Chatbot.</returns>
        public String endDialog()
        {
            int Hora = getHora();
            String despedida;
             if (this.personalidad == 1)
            {
                if (Hora >= 6 && Hora < 12)
                {
                    despedida = "Chatbot: Espero haberte sido de utilidad, que tengas un buen dia,¡Adiós!.";
                }
                else if (Hora >= 12 && Hora < 20)
                {
                    despedida = "Chatbot: Espero haberte sido de utilidad, que tengas una buena tarde,¡Adiós!.";
                }
                else if (Hora > 20)
                {
                    despedida = "Chatbot: Espero haberte sido de utilidad, que tengas una buena noche,¡Adiós!.";

                }
                else
                {
                    despedida = "Chatbot: Espero haberte sido de utilidad, ¡Hasta luego!.";
                }
            }
            else
            {
                despedida = "Chatbot: Dale compa, ¡Nos vemos!.";
            }
            return despedida;
        }

        /// <summary>
        /// Obtiene la hora actual, parámetro necesario para el correcto funcionamiento de otros métodos.
        /// </summary>
        /// <returns>Devuelve la hora actual.</returns>
        public int getHora()
        {
            DateTime momentoActual = DateTime.Now;
            int hora = momentoActual.Hour;
            return hora;
        }

    }
}
