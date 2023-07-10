# ApiRest.Net
Repositório para estudo de API Rest utiliando .net
Seguindo o curso de Api rest da Udemy
Ao final do curso será adicionado uma pasta chamado "Final challange" contendo um projeto de teste para os conceitos aprendidos.
Este teste não está previsto na udemy.
Este projeto usa startup e program como classes de inicialização.


VO -> Value Object
Também encontra-se como DTO.

Usado para esconder a real estrutura das entidades do banco de dados, omitindo ou facilitando o uso de certos valores.
A ideia principal é haver dois converters:
	1) Converte VO -> Entity
	2) Entity -> VO
Sabe-se que na camada de exposição (CONTROLLER) obtemos o objeto como um VO.
Ao começar o processamento da requisição, enviamos o objeto VO para a BUSINESS.
A Business possui uma dependência com uma classe Converter, pode-se mantê-la em um Helper e irá converter o VO.
	A classe Converter irá converter o objeto VO para Entity.
O objeto convertido é enviado para a REPOSITORY que irá persistir o objeto.
O contrário também é válido, resumindo a operação na conversão abaixo:
	1. Repository possui entity
	2. Business converte Entity para VO
	3. Controller possui objetoVO
	4. ObjetoVO exposto ao utilizador do sistema.
