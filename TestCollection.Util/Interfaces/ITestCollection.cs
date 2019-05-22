using System.Collections.Generic;

namespace TestCollection.Util.Interfaces
{
    /// <summary>
    /// O proposito desta interface é definir uma API para abstrair os detalhes técnicos de uma colecao de alta performance para adicionar, 
    /// recuperar e procurar um elemento em uma grande colecao de objetos.
    /// Exemplo de organização da estrutura
    /// 
    ///  ______________________________________________________
    /// |   chave        | subIndice | set                     |
    /// |------------------------------------------------------|
    /// |                | 1982      | amanda, joaquim, paulo  |
    /// | ano.nascimento |-------------------------------------|    
    /// |                | 1983      | bruna, joaquim, marta   |
    /// |------------------------------------------------------|
    /// |  cidades.sp    | 2000      | franca, sao paulo       |
    /// |______________________________________________________|
    /// 
    /// </summary>
    public interface ITestCollection
    {
        /// <summary>
        /// Adiciona um elemento na respectiva coleção representada pela chave. 
        /// Os elementos de uma coleção representada por uma chave são armazenados na memória em ordem crescente.
        /// Os elementos de uma coleção representada por uma chave não permite valores duplicados (funciona como um Set).
        /// Caso seja chamado esta API com um valor que já foi mapeado para a chave e para um subIndice, o valor antigo deve ser removido e o novo 
        /// valor deve ser adicionado na posição correta considerando ordem crescente. Exemplo: considerando a tabela acima, se adicionado o 
        /// elemento "amanda" para a chave "ano.nascimento" com o subIndice "1983", a tabela ficaria assim:
        ///  ___________________________________________________________
        /// |   chave        | subIndice | set                          |
        /// |-----------------------------------------------------------|
        /// |                | 1982      | joaquim, paulo               |
        /// | ano.nascimento |------------------------------------------|    
        /// |                | 1983      | amanda, bruna, joaquim, marta|
        /// |-----------------------------------------------------------|
        /// |  cidades.sp    | 2000      | franca, sao paulo            |
        /// |___________________________________________________________|
        /// </summary>
        /// <param name="key">a chave que mapeia o item</param>
        /// <param name="subIndex">um indice para agrupar os valores</param>
        /// <param name="value"></param>
        /// <returns>Retorna true se o elemento foi adicionado, caso o elemento está presente na lista retorna false e autaliza a posição de acordo
        ///  com a ordem crescente</returns>
        bool Add(string key, int subIndex, string value);

        /// <summary>
        /// Retorna uma lista com os valores que a chave esta armazenando de acordo com os limites de inicio e fim. 
        /// Os valores são unicos (não tem valor duplicado).
        /// A lista retornada esta ordenada em ordem crescente.
        /// O parâmetro start e end são indices no formato zero-base, onde o primeiro elemento é representado pelo indice 0, o segundo elemento com 
        /// indice 1 e assim por diante.
        /// O parâmetro start e end representam um range inclusivo, ou seja, se for requisitado start=1 e end=3, será retornado uma lista com três 
        /// elementos, com o segundo elemento, terceiro e quarto elemento da coleção solicitada.
        /// O parâmetro end pode ter valores negativos, neste caso ele funciona como um offset considerando o útimo elemento. Exemplo: -1 vai retornar 
        /// o último elemento, -2 vai retornar o penúltimo elemento e assim por diante.
        /// Caso o parâmetro start seja menor que zero, deve ser considerado como se fosse o primeiro elemento.
        /// Caso o parâmetro end seja maior que o numero de elementos, deve ser considerado como se fosse o último elemento.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        IList<string> Get(string key, int start, int end);

        /// <summary>
        /// Remove a chave com seus respectivos valores da coleção.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Retorna true se a chave foi removida, false caso a chave nao exista</returns>
        bool Remove(string key);


        /// <summary>
        /// Remove todos os valores associados com uma chave e um subIndex
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subIndex"></param>
        /// <returns>Retorna true se a chave tem um subIndex associado e ele foi removido, false caso contrario</returns>
        bool RemoveValuesFromSubIndex(string key, int subIndex);

        /// <summary>
        /// Retorna o indice que o elemento (value) esta posicionado.
        /// Este indice inicia com 0 e vai até tamanho da respectiva coleção considerando a chave.
        /// Exemplo, considere a tabela abaixo:
        ///  ______________________________________________________
        /// |   chave        | subIndice | set                     |
        /// |------------------------------------------------------|
        /// |                | 1982      | amanda, joao, pedro    |
        /// | ano.nascimento |-------------------------------------|    
        /// |                | 1983      | bruna, joao, maria      |
        /// |------------------------------------------------------|
        /// |  cidades.sp    | 2000      | franca, sao paulo       |
        /// |______________________________________________________|
        /// A chamada IndexOf("ano.nascimento", "bruna") vai retornar: 3
        /// A chamada IndexOf("ano.nascimento", "amanda") vai retornar: 0
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long IndexOf(string key, string value);
    }
}
