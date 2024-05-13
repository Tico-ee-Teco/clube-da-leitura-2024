﻿using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal class Repositoriobase
    {
        protected ArrayList registros = new ArrayList();

        protected int contadorId = 1;

        public void Cadastrar(EntidadeBase novoRegistro)
        {
            novoRegistro.Id = contadorId++;

           registros.Add(novoRegistro);
        }

        public bool Editar(int id, EntidadeBase novaEntidade)
        {
            novaEntidade.Id = id;

            foreach (EntidadeBase entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade.Id == id)
                {
                    entidade.AtualizarRegistro(novaEntidade);

                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int id)
        {
            foreach (EntidadeBase entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade.Id == id)
                {
                    registros.Remove(entidade);
                    return true;
                }
            }

            return false;
        }

        public ArrayList SelecionarTodos()
        {
            return registros;
        }

        public EntidadeBase SelecionarPorId(int id)
        {
            foreach (EntidadeBase entidade in registros)
            {               
                if (entidade == null)
                    continue;

                else if (entidade.Id == id)
                    return entidade;
            }

            return null;
        }

        public bool Existe(int id)
        {
            foreach (EntidadeBase entidade in registros)
            { 
                if (entidade == null)
                    continue;

                else if (entidade.Id == id)
                    return true;
            }

            return false;
        }
        
    }
}
