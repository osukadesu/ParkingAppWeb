import { Pipe, PipeTransform } from '@angular/core';
import { Cliente } from '../Parking/models/cliente';

@Pipe({
  name: 'filtroCliente'
})
export class FiltroClientePipe implements PipeTransform {

  transform(cliente: Cliente[], searchText: string): any {
    if (searchText == null) return cliente;
    return cliente.filter(p =>
      p.cedula.toLowerCase()
        .indexOf(searchText.toLowerCase()) !== -1);
  }
}
