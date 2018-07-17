import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProductPrintComponent } from './product-print.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: ProductPrintComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class  ProductPrintRoutingModule {

}