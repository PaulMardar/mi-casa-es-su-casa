
import requests
import json

_PROTOCOL     = "https"
_ENDPOINT     = "infura.io"
_VERSION      = "v3"
_GET_METHOD   = []
_PUBLIC_SET   = ["eth_blockNumber","eth_getBlockByNumber","eth_getBlockByHash","eth_getTransactionByHash","eth_getTransactionReceipt"]
_PRIVATE_SET  = ["eth_accounts"]
_POST_METHOD  = [
    "eth_getTransactionByHash","eth_getTransactionByBlockNumberAndIndex","eth_getTransactionByBlockHashAndIndex","eth_getStorageAt",
    "eth_getLogs","eth_getBlockTransactionCountByNumber","eth_getBlockTransactionCountByHash","eth_getBlockByHash",
    "eth_getBalance","eth_gasPrice","eth_estimateGas","eth_call","eth_blockNumber","eth_getBlockByHash","eth_getBlockByNumber",
    "eth_getTransactionByHash","eth_getTransactionReceipt","eth_accounts", "eth_getTransactionCount","eth_getUncleCountByBlockHash",
    "eth_getUncleCountByBlockNumber","eth_getUncleByBlockHashAndIndex","eth_getUncleByBlockNumberAndIndex","eth_hashrate","eth_mining",
    "eth_protocolVersion","eth_syncing","net_listening","net_peerCount","net_version","web3_clientVersion","eth_getWork"
    ]


class INFURA(object):
    def __init__( self ):
        self._URL  = "https://avalanche--fuji--rpc.datahub.figment.io/apikey/b032915d056bc51e76ea0843207d3461" # to change to a good url
    

    def api_call( self, _method, _params=[] ):
        _headers = {}
        _headers['Content-Type'] = "application/json"        
        _data = {"id":1,"method":_method,"params":_params}

        try: 
            if _method in _POST_METHOD:
                _type = "POST" 
                _rtn  = requests.post(self._URL,headers=_headers,data=json.dumps(_data))
            elif _method in _GET_METHOD:
                _type = "GET"
                _rtn  = requests.get(self._URL,headers=_headers,data=json.dumps(_data))                
            else:
                print(" Method [ {} ] cannot be found. Returning None ".format(_method))
                return None            
        except Exception as e:
            print("API Exception : {} ".format( str()) )
            return {} 
            
        return _rtn.json()

    def get_url( self ):
        return self._URL

    def get_accounts( self ):
        return self.api_call("eth_accounts",[])["result"] 

    def get_block_number( self ):
        _rtn = self.api_call("eth_blockNumber",[])
        return int(_rtn["result"],16)    

    def get_block_by_hash( self, _blk_hash,_tx_flag=True ):
        return self.api_call("eth_getBlockByHash",[str(_blk_hash),_tx_flag])

    def get_block_by_number( self, _blk_num, _tx_flag=True ):
        return self.api_call("eth_getBlockByNumber",[hex(_blk_num),_tx_flag])

    def get_transaction_by_hash( self, _tx_hash ):
        return self.api_call("eth_getTransactionByHash",[str(_tx_hash)])

    def get_transaction_receipt( self, _tx_hash ):
        return self.api_call("eth_getTransactionReceipt",[str(_tx_hash)])

    def make_eth_call( self, *args, **kwargs):    
        return self.api_call( "eth_call", [kwargs, args[0]] )

    def get_gas_estimate( self, *args, **kwargs ):
        return self.api_call( "eth_estimateGas",[kwargs] )        

    def get_gas_price( self ):
        return self.api_call( "eth_gasPrice", [] )

    def get_balance( self, _address, _blk_param ):
        return self.api_call( "eth_getBalance", [str(_address),_blk_param] )


    def get_code( self, _address, _blk_param ):
        return self.api_call( "eth_getCode", [str(_address),str(_blk_param)] )
    

    def get_logs( self, _filter_object ):
        return self.api_call("eth_getLogs",[_filter_object] )

    def get_storage_at( self, _address, _storage_pos, _blk_param ):
        return self.api_call("eth_getStorageAt",[str(_address),_storage_pos,_blk_param])

    def get_tx_by_block_hash_and_index( self,_tx_hash,_tx_index ):
        return self.api_call("eth_getTransactionByBlockHashAndIndex",[str(_tx_hash),str(_tx_index)])

    def get_tx_count( self,_address, _blk_param ):
        return self.api_call("eth_getTransactionCount",[str(_address),_blk_param])

    def get_uncle_count_by_block_hash( self, _blk_hash):
        return self.api_call("eth_getUncleCountByBlockHash",[_blk_hash])
    

    def get_uncle_count_by_block_number( self, _blk_number):
        return self.api_call("eth_getUncleCountByBlockNumber",[_blk_number])


    def get_uncle_by_block_hash_and_index( self, _blk_hash,_uncle_index):
        return self.api_call("eth_getUncleByBlockHashAndIndex",[_blk_hash,_uncle_index])
    

    def get_net_version( self ):
        return self.api_call("net_version",[])

    def get_client_version( self ):
        return self.api_call("web3_clientVersion",[])


    def get_work( self ):
        return self.api_call("eth_getWork",[])

    def submit_work( self ):
        pass 

    def send_raw_transaction( self, _tx_data={}):
        pass 


    
