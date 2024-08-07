import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Button } from 'semantic-ui-react';
import { DeleteWarehouseProduct } from './WarehouseAction';
import { SetProductViewModal, SetProductViewModalContentAndHeader } from './ProductViewModal/ProdctViewModalAction';
import { withRouter } from 'react-router-dom';


class WarehouseActionButtons extends Component
{
    onClickHandler = (event, data) => {
        const productId = this.props.data.productId;
        switch(data.name) {
            case "delete":
                this.props.DeleteWarehouseProduct(productId);
                break;
            case "view":
                this.props.SetProductViewModalContentAndHeader(productId);
                this.props.SetProductViewModal(true);
                break;
            default:
                break;
        }
    }
    render() {
        return (
            <div>
                <Button color='blue' onClick={this.onClickHandler} name = 'view'>VIEW</Button>
                <Button color='red' loading={this.props.main.isButtonLoading} onClick={this.onClickHandler} name = 'delete'>DELETE</Button>
            </div>
        );
    }
}

function MapStateToProps(state) {
    return {
        main: state.main
    };
}

export default withRouter(
    connect( MapStateToProps, {DeleteWarehouseProduct, SetProductViewModal, SetProductViewModalContentAndHeader})
(WarehouseActionButtons));