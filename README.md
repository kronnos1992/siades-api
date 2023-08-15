# SIADES-API.AO

## SOBRE A APLICAÇÃO

### DESCRIÇÃO

    *   APP: sistema de admisitração e distribuição de dados sanguineos (backend - api)
    *   Desenvolvedor: Jaime Kiala Coxi
    *   Ano: 2023
    *   Versão 1.0
    *   website: http://siades-api.somee.com/

### CADASTROS - CASOS DE USO

    *   Medico
    *   Doador
    *   Grupo Sanguineo
    *   Endereço(País, Provincia, Municipio...)
    *   Contactos
    *   Hospitais
    *   Pedidos
    *   Especialidades
    *   Doações
    *   Usuarios
    *   Regras

### REQUISITOS FUNCIONAIS

    =>  GERENCIAR PEDIDOS
            Registrar os pedidos
            definir o estado do pedido(pendente, aceito, recusado) 
    
    =>  GERENCIAR DOADORES
            Cadastrar os dadores
            definir a condição de doação de acordo aos dados clínicos
            Notoficar o dador periodicamente sobre novidades e a data da proxima doação
    
    =>  GERENCIA DE STOCK
            Registrar os grupos sanguineos no stock
            atualizar a quantidade em função as doações
            atualizar a quantidade em função aos pedidos aceites

### REQUISITOS NÃO FUNCIONAIS

    *   O sistema é executal em qualquer sistema operacional(localmente)
    *   O sistema roda em mais de 5 navegadores web(conhecidos hoje)

### REGRAS DE NEGÓCIO

    *   Se a condição clínica do dador não for apto, deve regeitar o registro da doação
    *   Se a idade do dador for inferior aos 18 anos o sistema não deve validar a doação
    *   Se a diferença entre a data da ultima doação e a data atual for inferior a 3 meses, o sistema deve regeitar a doação
    *   Se a quantidade do plaquetas de sangue em Stock for enferior a 10, o sistema deve emitir um alerta de baixa de stock
