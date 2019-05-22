# TestCollection
Foi criado uma web.api para adicionar itens em uma coleção de dados chamada TestCollection

# Para usar com o Docker:
1- Clonar para a pasta que desejar;
2- Abrir o CMD, e ir até o diretório do projeto, na pasta que tem o arquivo **docker-compose.yml**;
3- Digitar o comando para criar a external network: **docker network create TestCollection**
4- Digitar o comando para fazer o build e subir o container: **docker-compose -f docker-compose.yml up -d --build**
5- Acessar a WebApi pelo seguinte caminho: http://localhost:9092/swagger/index.html

# Para rodar normalmente no IIS:
1- Acessar a Solution do projeto;
2- Alterar o "Run" do VS de Docker para IIS Express
