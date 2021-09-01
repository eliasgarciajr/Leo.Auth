1) Criar uma Solution que tenha ao menos um projeto de API e um
projeto de teste de unidade:
➢ Linguagem: C#
➢ Versão: .Net 5
➢ Ambiente de Execução: Deve ser possível executar em Docker e Kestrel
➢ Autenticação da API: Token JWT
➢ IDE: Visual Studio ou VS Code
2) A API deve possuir os seguintes métodos:
Método 1: Tem o objetivo de retornar o token de autenticação para os métodos 2 e 3.
Este método não exige autenticação. Use a sua criatividade para validar o user e senha.
Pode ser fixo, banco, etc.
✓ Parâmetros de Entrada: usuário e senha.
✓ Parâmetros de Saída: usuário, autenticado (True/False), token e data de
expiração do Token.
✓ Observação importante: O token deve ser válido por 5 minutos.
Método 2: Tem o objetivo de validar se determinada senha é válida de acordo com as
regras abaixo:
✓ Conter no mínimo 15 caracteres.
✓ No mínimo uma letra maiúscula.
✓ No mínimo uma letra minúscula.
✓ No mínimo um dos seguintes caracteres especiais: (@,#,_,- e !).
✓ Não poder ter caracteres repetidos em sequência, por exemplo: 1111,
aaaa, bbbb, @@@@, BBBB.
✓ Prever case-sensitive, por exemplo: A é diferente de a.
✓ Parâmetros de Entrada: senha a ser validada.
✓ Parâmetros de Saída: senha válida (True/False).
✓ Observação importante: Este método exige autenticação, ou seja, ele só
poderá ser chamado se o token JWT estiver válido.
Método 3: Tem o objetivo de criar uma senha, levando em consideração as mesmas
regras descritas no Método 2.
✓ Parâmetros de Entrada: nenhum.
✓ Parâmetros de Saída: senha válida criada.
✓ Observação importante: Este método exige autenticação, ou seja, ele só
poderá ser chamado se o token JWT estiver válido.
3) Sobre o projeto de teste de unidade:
✓ Pode usar qualquer tecnologia e deve estar dentro da solution.
✓ Deve apresentar testes para os métodos 1,2,3.
4) Regras gerais e recomendações:
✓ Utilize sempre que possível os conceitos do S-O-L-I-D.
✓ Remova varáveis e componentes (pacotes Nuget) não utilizados.
Deixe a solution com o mínimo necessário para execução.
✓ Fique à vontade para escolher a quantidade de camadas, estrutura,
componentes e modelo arquitetural da sua solution.
✓ A solution pode conter internamente mais projetos, mas no mínimo,
o projeto da API e o projeto de teste de unidade.
✓ A solution deve ter o seguinte nome: prjslnback-seunomeseuultimonome. Ela deve ser salva no seu Git Hub em um
repositório público. O endereço completo deste repositório deve ser
disponibilizado e obrigatoriamente deve ter o seguinte nome
prjgitback-seunome-seuultimonome.

