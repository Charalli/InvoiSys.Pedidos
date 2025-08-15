let index = 0;

document.getElementById("form-pedidos").addEventListener("submit", function (event) {
    if (!Validar_ItensDoPedido() || !Validar_DataPrevistaEntrega()) {
        event.preventDefault();
    }
});

document.getElementById("adicionarItens").addEventListener("click", function () {
    const CodigoDoProduto = document.getElementById("CodigoDoProduto").value;
    const Quantidade = document.getElementById("Quantidade").value;
    const DescricaoDoProduto = document.getElementById("DescricaoDoProduto").value;
    const ValorDoProduto = document.getElementById("ValorDoProduto").value;

    if (!CodigoDoProduto || !Quantidade || !DescricaoDoProduto || !ValorDoProduto) {
        alert("Preencha todos os campos do item!");
        return;
    }

    const newRow = document.createElement('tr');
    newRow.innerHTML = `
        <td>
            <input type="hidden" name="ListaItensDoPedido[${index}].CodigoDoProduto" value="${CodigoDoProduto}" />
            ${CodigoDoProduto}
        </td>
        <td>
            <input type="hidden" name="ListaItensDoPedido[${index}].Quantidade" value="${Quantidade}" />
            ${Quantidade}
        </td>
        <td>
            <input type="hidden" name="ListaItensDoPedido[${index}].DescricaoDoProduto" value="${DescricaoDoProduto}" />
            ${DescricaoDoProduto}
        </td>
        <td>
            <input type="hidden" name="ListaItensDoPedido[${index}].ValorDoProduto" value="${ValorDoProduto}" />
            R$ ${ValorDoProduto}
        </td>
        <td>
            <button type="button" class="btn btn-danger btn-sm removeItem">Remover</button>
        </td>
    `;

    document.getElementById("itensTable").appendChild(newRow);

    // Limpa os campos
    document.getElementById("CodigoDoProduto").value = "";
    document.getElementById("Quantidade").value = "";
    document.getElementById("DescricaoDoProduto").value = "";
    document.getElementById("ValorDoProduto").value = "";

    index++;
});

document.addEventListener('click', function (e) {
    if (e.target && e.target.classList.contains('removeItem')) {
        e.target.closest('tr').remove();

        // Atualiza os índices dos itens restantes
        updateItemIndexes();
    }
});

function updateItemIndexes() {
    const rows = document.querySelectorAll("#itensTable tr");
    index = 0;

    rows.forEach((row, i) => {
        const hiddenInputs = row.querySelectorAll("input[type='hidden']");
        hiddenInputs.forEach(input => {
            const name = input.name.replace(/\[\d+\]/, `[${i}]`);
            input.name = name;
        });
        index = i + 1;
    });
}

function Validar_ItensDoPedido() {
    const itensTable = document.getElementById("itensTable");
    const rows = itensTable.getElementsByTagName("tr");

    if (rows.length === 0) {
        alert("Adicione pelo menos um item ao pedido antes de enviar!");
        return false;
    }

    return true;
}

function Validar_DataPrevistaEntrega() {
    const dataEntrega = document.getElementById("DataPrevistaEntrega").value;
    const dataAtual = new Date();
    const dataEntregaObj = new Date(dataEntrega);

    if (dataEntregaObj < dataAtual) {
        alert("A data de entrega não pode ser anterior à data atual.");
        return false;
    }

    return true;
}