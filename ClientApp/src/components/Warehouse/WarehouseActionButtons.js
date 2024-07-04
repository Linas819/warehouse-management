import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Button } from 'semantic-ui-react';
import { DeleteInventoryItem } from './WarehouseAction';

class WarehouseActionButtons extends Component
{
    onClickHandler = (event, data) => {
        const productId = this.props.data.productId;
        switch(data.name) {
            case "delete":
                this.props.DeleteInventoryItem(productId);
                break;
            default:
                break;
        }
    }
    render() {
        return (
            <div>
                <Button color='grey' onClick={this.onClickHandler} name = 'view'>VIEW</Button>
                <Button color='blue' onClick={this.onClickHandler} name = 'edit'>EDIT</Button>
                <Button color='red' onClick={this.onClickHandler} name = 'delete'>DELETE</Button>
            </div>
        );
    }
}

function MapStateToProps(state) {
    return {
        main: state.main
    };
}

export default connect( MapStateToProps, {DeleteInventoryItem})(WarehouseActionButtons);