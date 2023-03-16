import { FormEvent, useState } from 'react';
import Modal from 'react-modal'

import { FormContainer, TransactionType, RadioBox } from './styles'
import closeImg from '../../assets/close.svg';
import incomeImg from '../../assets/income.svg';
import outcomeImg from '../../assets/outcome.svg';
import { useTransactions } from '../../hooks/useTransactions';
//import { TransactionsContext } from '../../TransactionsContext'

Modal.setAppElement('#root')  //opcional, questão de acessibilidade

type NewTransactionProps = {
  isOpen: boolean;
  onRequestClose: () => void;
}

export function NewTransactionModal(props: NewTransactionProps) {
  const { createTransaction } = useTransactions()
  //const { createTransaction } = useContext(TransactionsContext);

  const [type, setType] = useState('entrada')
  const [title, setTitle] = useState('')
  const [amount, setAmount] = useState(0)
  const [category, setCategory] = useState('')
  
  async function handleCreateNewTransaction(event: FormEvent) {
    event.preventDefault()

    await createTransaction({
      title,
      amount,
      category,
      type      
    })

    setTitle('')
    setAmount(0)
    setCategory('')
    setType('entrada')
    props.onRequestClose()
  }

  return (
    <Modal 
      isOpen={props.isOpen}
      onRequestClose={props.onRequestClose}
      overlayClassName="react-modal-overlay"
      className="react-modal-content"
    >
      <button type="button" 
        onClick={props.onRequestClose}
        className="react-modal-close"
        >
        <img src={closeImg} alt="Fechar modal" />
      </button>

      <FormContainer onSubmit={handleCreateNewTransaction}>
        <h2>Cadastrar transação</h2>

        <input placeholder="Descrição" 
          value={title}
          onChange={event => setTitle(event.target.value)}
        />

        <input type="number" 
          placeholder="Valor"
          value={amount.toString()}
          onChange={event => setAmount(Number(event.target.value))}
        />

        <TransactionType>
          <RadioBox type="button" 
            onClick={() => setType('credit')} 
            isActive={type === 'credit'}
            activeColor="#33cc95"
          >
            <img src={incomeImg} alt="Crédito" />
            <span>Crédito</span>
          </RadioBox>
          
          <RadioBox type="button" 
            onClick={() => setType('debit')} 
            isActive={type === 'debit'}
            activeColor="#e52e4d"
          >
            <img src={outcomeImg} alt="Débito" />
            <span>Débito</span>        
          </RadioBox>                
        </TransactionType>

        <input placeholder="Categoria" 
          value={category}
          onChange={event => setCategory(event.target.value)}
        />

        <button type="submit">Cadastrar</button>
      </FormContainer>
    </Modal>    
  )
}