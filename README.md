# Validar Senha
A API está disponibilizada em API REST que permite que você valide as senhas conforme itens de seguranças já estabelecidos.

##Métodos
Requisições para a API devem seguir os padrões:
| Método | Descrição |
|---|---|
| `POST ValidarSenha` | Utilizado para validar a senha. |

## Respostas
| Código | Descrição |
|---|---|
| `200` | Requisição executada com sucesso (success).|
| `400` | Erros de validação ou os campos informados não existem no sistema.|
| `500` | Erros de processamento da requisição.|

### Validar Senha [POST]
+ Attributes (object)
+ senha: senha do usuario (string, required)
+ Request (application/json)
 + Body
 {
  "senha": "string"
}
+ Response 200 (application/json)
+ Headers
 content-type: application/json; charset=utf-8 
 date: Sun, 27 Jun 2021 00:31:55 GMT 
 server: Microsoft-IIS/10.0 
 x-powered-by: ASP.NET 
+ Body

            {
                True
            }
