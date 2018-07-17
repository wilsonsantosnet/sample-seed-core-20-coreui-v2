import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProductComponent } from './product.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductCreateComponent } from './product-create/product-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "Product" }, component: ProductComponent },
            { path: 'edit/:id', data : { title : "Product" } ,component: ProductEditComponent },
            { path: 'details/:id', data : { title : "Product" }, component: ProductDetailsComponent },
            { path: 'create', data : { title : "Product" }, component: ProductCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class ProductRoutingModule {
}