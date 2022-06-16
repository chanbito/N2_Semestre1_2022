#include <stdio.h>
#include <stdlib.h>

struct no{
    int info;
    struct no* elo_anterior;
	struct no* elo_proximo;
};

typedef struct no No;

struct fila{
    No* inicio;
    No* fim;
};

typedef struct fila Fila;

Fila* cria(){
    Fila* fila = (Fila*) malloc(sizeof(Fila));
    fila->inicio = NULL;
    fila->fim = NULL;
    return fila;
}

No* insere_inicio(No* fim , int info, No* inicio){
    No* no = (No*) malloc(sizeof(No));
    no->info = info;
	//se o inicio for nullo, a fila esta vazia
    if(inicio == NULL){
        no->elo_anterior = no;
        no->elo_proximo = no;
    }else{
    	no->elo_proximo = inicio;
    	no->elo_anterior = fim;
    	inicio->elo_anterior = no;
    	fim->elo_proximo = no;
    }
    return no;
}

No* insere_fim(No* fim , int info, No* inicio){
    No* no = (No*) malloc(sizeof(No));
    no->info = info;
	//se o fim for nullo, a fila esta vazia
    if(fim == NULL){
        no->elo_anterior = no;
        no->elo_proximo = no;
    }else{
    	
    	no->elo_proximo = inicio;
    	no->elo_anterior = fim;
    	fim->elo_proximo = no;
    	inicio->elo_anterior = no;
    }
    return no;
}

void enqueue_fim(Fila* fila , int info){
    fila->fim = insere_fim( fila->fim, info, fila->inicio);
    if(fila->inicio == NULL){
        fila->inicio = fila->fim;
    }
}

void enqueue_inicio(Fila* fila , int info){
    fila->inicio = insere_inicio( fila->fim, info, fila->inicio);
    if(fila->fim == NULL){
        fila->fim = fila->inicio;
    }
}

No* retira_inicio(No* inicio, No* fim){
    No* no = inicio->elo_proximo;
    if(inicio == fim){
        free(inicio);
        no = NULL;
    }else{
        free(inicio);
        fim->elo_proximo = no;
        no->elo_anterior = fim;
    }
    return no;
}

No* retira_fim(No* inicio, No* fim){
    No* no = fim->elo_anterior;
    if(inicio == fim){
        free(fim);
        no = NULL;
    }else{
        free(fim);
        inicio->elo_anterior = no;
        no->elo_proximo = inicio;
    }
    return no;
}

int dequeue_fim(Fila* fila){
    fila->fim = retira_fim(fila->inicio, fila->fim);
    if (fila->fim == NULL){
        fila->inicio = NULL;
    }
}

int dequeue_inicio(Fila* fila){
    fila->inicio = retira_inicio(fila->inicio, fila->fim);
    if (fila->inicio == NULL){
        fila->fim = NULL;
    }
}

void buscar(Fila* fila, int valor){
	No* no;
    no = fila->inicio;
    int contador = 0;
    do{
    	if(no->info == valor){
    		printf("No %p => |ELO_ANTERIOR: %p| INFO: %d | ELO_PROXIMO: %p| \n", no, no->elo_anterior, no->info, no->elo_proximo);
			contador++;
		}
        no = no->elo_proximo;
    }while(no != fila->inicio && contador == 0);
    if(no == fila->inicio){
    	printf("Valor nao encontrado");
	}
    printf("\n\n");
}

void imprime(Fila* fila){
    No* no;
    no = fila->inicio;
    printf("\nFila: %p \nFila->Inicio: %p\nFila->Fim: %p\n", fila, fila->inicio, fila->fim);
    do{
        printf("No %p => |ELO_ANTERIOR: %p| INFO: %d | ELO_PROXIMO: %p| \n", no, no->elo_anterior, no->info, no->elo_proximo);
        no = no->elo_proximo;
    }while(no != fila->inicio);
    
    printf("\n\n");
}
//até aqui pronto mas n testado
void libera(Fila* fila){
    No* no;
    No* no_anterior;
    for(no = fila->inicio; no != NULL; no = no_anterior){
        no_anterior = no->elo_anterior;
        free(no);
    }
    free(fila);
}

int main(){

    Fila* f1;

    f1 = cria();


    enqueue_inicio(f1, 1);
    enqueue_inicio(f1, 2);
    enqueue_inicio(f1, 3);
    enqueue_fim(f1, 4);
    enqueue_inicio(f1, 10);
    imprime(f1);

	
	buscar(f1,2);
	buscar(f1,20);
    dequeue_inicio(f1);
    imprime(f1);
    dequeue_fim(f1);
    imprime(f1);
    dequeue_fim(f1);
    imprime(f1);
    dequeue_inicio(f1);
    imprime(f1);
    dequeue_inicio(f1);
    imprime(f1);
    /*dequeue(f1);
    imprime(f1);*/

    libera(f1);


}
