# Shows4All
A empresa Shows4All apresenta-se como uma concorrente da Netflix.

-----------
#Extensões Instaladas:
-----------



-----------
#Contas para Login (Se for necessário criar mais alguma, tem de se adicionar um user ao ClienteDB:
-----------

- Admin: Elson2 ola
- Cliente: Elson ola


-----------
#Informações:
-----------
Neste projeto, foi primeiro construido o Diagrama de Classes, o Modelo da Base de Dados e as Páginas do Website, no ficheiro Shows4All.drawio (Se usar dark mode, por favor abrir no website: draw.io).
Depois de planeada esta arquitetura, foi construida a aplicação tendo em conta a mesma.

-----------
#Modelo usado:
-----------

Neste projeto, adotei o padrão arquitetónico MVVM (Model-View-ViewModel) como base para a minha aplicação ASP.NET:

View: As minhas vistas são implementadas como Razor Pages, que residem em classes HTML. Por exemplo, pode verificar o ficheiro SerieInfo.cshtml.

ViewModel: Os componentes ViewModel da minha aplicação são representados pelas minhas classes em C#, como SerieInfo.cshtml.cs. Estas classes facilitam a comunicação entre as minhas vistas e os dados subjacentes.

Model: Os meus modelos servem como modelos para várias classes no meu projeto. Fornecem a estrutura necessária para que a base de dados armazene informações e permitem-me recuperar os dados necessários para construir essas classes. 
Pode encontrar essas classes de modelo no diretório 'Models'.

Seguindo o padrão MVVM, organizei o meu projeto em camadas distintas, cada uma com a sua função específica, garantindo clareza e facilidade de manutenção no desenvolvimento da minha aplicação.


