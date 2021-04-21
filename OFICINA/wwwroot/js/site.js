$(document).ready(function () {
    $('#btnSalvar').off("click")
    $('#btnSalvar').on('click', function (event) {
        event.preventDefault();

        let cliente = $('#txtCliente').val();
        let Data = $('#txtData').val();
        let Vendedor = $('#txtVendedor').val();
        let Descricao = $('#txtDescricao').val();
        let Valor = $('#txtValor').val();

        $.ajax({

            url: "/home/CadastrarOrcamento",
            data: {
                'NomeCliente': cliente, 'DataOrcamento': Data, 'Vendedor': Vendedor, 'DescricaoOrcamento': Descricao, 'ValorOrcado': Valor
            },
            type: 'POST'

        })

            .done(function (event) {

                alert("Cadastrado com sucesso");
                event.preventDefault();

            });


    });



    $("#txtFiltro").on("keyup", function () {

        var value = $(this).val().toLowerCase();


        $("#tabela tr").filter(function () {


            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)

        });
    });
});

function deletar(x) {

    $.ajax({
        url: "/home/DeletarOrcamento/?codCliente=" + x,

        type: 'DELETE'
    })
        .done(function (data) {
            window.location.href = "/home/Consulta";

            alert(data + '')
        });
}

function editar(x) {
    window.location.href = "/home/EditarOrcamento/?id=" + x;
}

function editarOrcamento(x) {

    $.ajax({
        url: "/home/AlterarOrcamento/?codCliente=" + x,

        type: 'PUT'
    })
        .done(function (data) {
            window.location.href = "/home/Consulta";

            alert(data + '')
        });
}



