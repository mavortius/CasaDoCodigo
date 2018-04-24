class Carrinho {
    incrementaQuantidade(btn) {
        let data = this.getData(btn);
        
        data.Quantidade++;
        this.postQuantidade(data);   
    }
    
    decrementaQuantidade(btn) {
        let data = this.getData(btn);

        data.Quantidade--;
        this.postQuantidade(data);
    }
    
    updateQuantidade(input) {
        var data = this.getData(input);
        
        this.postQuantidade(data);
    }

    getData(elemento) {
        let linhaDoItem = $(elemento).parents('[item-id]');
        let itemId = linhaDoItem.attr('item-id');
        let novaQtde = linhaDoItem.find('input').val();

        return {
            Id: itemId,
            Quantidade: novaQtde
        };
    }
    
    setQuantidade(itemPedido) {
        $(`[item-id=${itemPedido.id}]`)
            .find('input').val(itemPedido.quantidade);
    }

    setSubtotal(itemPedido) {
        $(`[item-id=${itemPedido.id}]`)
    }
    
    postQuantidade(data) {
        postAjax('/pedido/postQuantidade', data)
            .done(function (response) {
                this.setQuantidade(response.itemPedido);
            }.bind(this));
    }
}