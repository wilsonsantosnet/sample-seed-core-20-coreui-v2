import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ProductPrintComponent } from './product-print.component';
import { ProductPrintRoutingModule } from './product-print.routing.module';

import { ProductService } from '../product.service';
import { ApiService } from '../../../common/services/api.service';
import { ProductServiceFields } from '../product.service.fields';

import { ProductContainerDetailsComponent } from '../product-container-details/product-container-details.component';
import { ProductFieldDetailsComponent } from '../product-field-details/product-field-details.component';
import { CommonSharedModule } from '../../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        CommonSharedModule,
        ProductPrintRoutingModule,
        FormsModule
    ],
    declarations: [
        ProductPrintComponent,
        ProductContainerDetailsComponent,
        ProductFieldDetailsComponent
    ],
    providers: [ProductService, ApiService, ProductServiceFields],
    exports: [ProductContainerDetailsComponent,ProductFieldDetailsComponent]
})
export class ProductPrintModule {

}
