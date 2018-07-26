import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';

import { ProductComponent } from './product.component';

import { ProductContainerFilterComponent } from './product-container-filter/product-container-filter.component';
import { ProductFieldFilterComponent } from './product-field-filter/product-field-filter.component';

import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductCreateComponent } from './product-create/product-create.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

import { ProductFieldCreateComponent } from './product-field-create/product-field-create.component';
import { ProductFieldEditComponent } from './product-field-edit/product-field-edit.component';

import { ProductContainerCreateComponent } from './product-container-create/product-container-create.component';
import { ProductContainerEditComponent } from './product-container-edit/product-container-edit.component';

import { ProductPrintModule } from './product-print/product-print.module';
import { ProductRoutingModule } from './product.routing.module';

import { ProductService } from './product.service';
import { ProductServiceFields } from './product.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        ProductRoutingModule,
        ProductPrintModule,

    ],
    declarations: [
        ProductComponent,
        ProductContainerFilterComponent,
        ProductFieldFilterComponent,
        ProductEditComponent,
        ProductCreateComponent,
        ProductDetailsComponent,
        ProductFieldCreateComponent,
        ProductFieldEditComponent,
        ProductContainerCreateComponent,
        ProductContainerEditComponent
    ],
    providers: [ProductService,ProductServiceFields, ApiService],
	exports: [ProductComponent, ProductEditComponent, ProductCreateComponent]
})
export class ProductModule {


}
