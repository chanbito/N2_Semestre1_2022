#include <stdio.h>
#include <stdlib.h>

struct no{
    int info;
    struct no* elo;
};

typedef struct no No;

struct lista{
    No* inicio;
    No* fim;
};

typedef struct lista Lista;

Lista* cria(){
    Lista* lista = (Lista*) malloc(sizeof(Lista));
    lista->inicio = NULL;
    lista->fim = NULL;
    return lista;
}

No* insere_fim(No* fim , int info){
    No* no = (No*) malloc(sizeof(No));
    no->info = info;
    no->elo = NULL;
    if (fim != NULL){
        fim->elo = no;
    }
    return no;
}

No* insere_inicio(No* inicio , int info){
    No* no = (No*) malloc(sizeof(No));
    no->info = info;
    no->elo = inicio;
    return no;
}

void enqueue_fim(Lista* lista , int info){
    lista->fim = insere_fim(lista->fim , info);
    if(lista->inicio == NULL){
        lista->inicio = lista->fim;
    }
}

void enqueue_inicio(Lista* lista , int info){
    lista->inicio = insere_inicio(lista->inicio , info);
    if(lista->fim == NULL){
        lista->fim = lista->inicio;
    }
}

No* retira(Lista* lista, int valor){
    No* no;
    No* no_anterior = NULL;
	for(no = lista->inicio; no != NULL; no = no->elo){
		if(no->info == valor){
			//achei, testar algumas coisas
			
			if(lista->fim == lista->inicio){
				free(no);
				lista->fim = NULL;
				lista->inicio = NULL;
				return NULL;
			}
			
			if(no == lista->fim){
				
				no_anterior->elo = NULL;
				lista->fim = no_anterior;
				free(no);
				return no_anterior;	
			}
			if(no == lista->inicio){
				
				lista->inicio = no->elo;
			}
			if(no_anterior != NULL){
				
				no_anterior->elo = no->elo;
			}
			free(no);
			return no_anterior;	
		}
        no_anterior = no;
	}
    return no;
}

int dequeue(Lista* lista, int valor){
    retira(lista, valor);
}
//ate aqui ok

void imprime(Lista* lista){
    No* no;
    no = lista->inicio;
    printf("\nLista: %p \nLista->Inicio: %p\nLista->Fim: %p\n", lista, lista->inicio, lista->fim);
    do{
        printf("No %p => | INFO: %d | ELO: %p| \n", no, no->info, no->elo);
        no = no->elo;
    }while(no != NULL);
    
    printf("\n");
}

void buscar(Lista* lista, int valor){
	No* no;
    no = lista->inicio;
    int contador = 0;
    do{
    	if(no->info == valor){
    		printf("ACHEI:\n");
    		printf("No %p => |INFO: %d | ELO: %p| \n", no, no->info, no->elo);
			contador++;
		}
        no = no->elo;
    }while(no != NULL && contador == 0);
    if(no == NULL){
    	printf("Valor nao encontrado");
	}
    printf("\n\n");
}

void libera(Lista* lista){
    No* no;
    No* no_proximo;
    for(no = lista->inicio; no != NULL; no = no_proximo){
        no_proximo = no->elo;
        free(no);
    }
    free(lista);
}

int main(){

    Lista* list1;

    list1 = cria();
    enqueue_fim(list1, 14);
    imprime(list1);
    enqueue_inicio(list1, 10);
    imprime(list1);
    enqueue_fim(list1, 77);
    imprime(list1);
    buscar(list1,10);
    buscar(list1,99);
    dequeue(list1,14);
    dequeue(list1,77);
    imprime(list1);
    dequeue(list1,10);
    imprime(list1);
    libera(list1);
}
